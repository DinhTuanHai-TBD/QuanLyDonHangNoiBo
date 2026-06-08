namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public DashboardDto GetDashboard(Guid? tenantId)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var now = DateTimeOffset.UtcNow;
        var orders = _repository.Orders.Where(item => item.TenantId == resolvedTenantId).ToList();
        var shipments = _repository.Shipments.Where(item => item.TenantId == resolvedTenantId).ToList();
        var cods = _repository.CodCollections.Where(item => item.TenantId == resolvedTenantId).ToList();
        var stocks = GetInventoryStocks(resolvedTenantId, null, null);
        var today = now.UtcDateTime.Date;
        var delivered = orders.Where(item => item.Status == OrderStatus.Delivered).ToList();
        var lateOrders = orders.Where(item =>
            item.SlaDeadline.HasValue &&
            item.SlaDeadline.Value < now &&
            item.Status is not (OrderStatus.Delivered or OrderStatus.Cancelled or OrderStatus.Returned)).ToList();

        var kpis = new List<KpiDto>
        {
            new("ordersToday", "Don moi hom nay", orders.Count(item => item.CreatedAt.UtcDateTime.Date == today).ToString("N0"), "info", 12),
            new("processing", "Don dang xu ly", orders.Count(item => item.Status is OrderStatus.Confirmed or OrderStatus.WaitingPick or OrderStatus.Picking or OrderStatus.Packed or OrderStatus.ReadyToShip).ToString("N0"), "warning", 4),
            new("deliveryRate", "Ty le giao thanh cong", FormatPercent(orders.Count == 0 ? 0 : delivered.Count / (decimal)orders.Count), "success", 3),
            new("revenue", "Doanh thu da giao", FormatMoney(delivered.Sum(item => item.Total)), "success", 18),
            new("codPending", "COD cho doi soat", FormatMoney(cods.Where(item => item.Status is CodStatus.Pending or CodStatus.Collected).Sum(item => item.ExpectedAmount)), "critical", -8),
            new("lowStock", "SKU sap het hang", stocks.Count(item => item.IsLowStock).ToString("N0"), "critical", -2)
        };

        var statusBreakdown = Enum.GetValues<OrderStatus>()
            .Select(status => new StatusMetricDto(status.ToString(), orders.Count(item => item.Status == status)))
            .Where(item => item.Count > 0)
            .ToList();

        var alerts = new List<OperationalAlertDto>();
        alerts.AddRange(lateOrders.Take(3).Select(item => new OperationalAlertDto(
            "Don co nguy co tre SLA",
            $"{item.OrderCode} da qua han xu ly, can dieu phoi lai.",
            NotificationSeverity.Critical,
            $"/orders/{item.Id}")));
        alerts.AddRange(stocks.Where(item => item.IsLowStock).Take(3).Select(item => new OperationalAlertDto(
            "Canh bao ton kho thap",
            $"{item.SkuCode} tai {item.WarehouseCode} chi con {item.Available} san pham kha dung.",
            NotificationSeverity.Warning,
            "/inventory")));

        if (shipments.Any(item => item.Status == ShipmentStatus.Failed))
        {
            alerts.Add(new OperationalAlertDto(
                "Co don giao that bai",
                $"{shipments.Count(item => item.Status == ShipmentStatus.Failed)} shipment can xu ly giao lai hoac hoan hang.",
                NotificationSeverity.Warning,
                "/delivery"));
        }

        var pipelineStatuses = new[] { OrderStatus.Confirmed, OrderStatus.Picking, OrderStatus.Packed, OrderStatus.InTransit };
        var pipeline = pipelineStatuses
            .Select(status => new PipelineColumnDto(
                status.ToString(),
                orders.Count(item => item.Status == status),
                orders.Where(item => item.Status == status).OrderByDescending(item => item.CreatedAt).Take(4).Select(ToOrderSummaryDto).ToList()))
            .ToList();

        return new DashboardDto(
            kpis,
            statusBreakdown,
            orders.OrderByDescending(item => item.CreatedAt).Take(8).Select(ToOrderSummaryDto).ToList(),
            alerts,
            _repository.AiInsights.Where(item => item.TenantId == resolvedTenantId).OrderByDescending(item => item.CreatedAt).Take(4).Select(ToAiInsightDto).ToList(),
            pipeline);
    }
}

