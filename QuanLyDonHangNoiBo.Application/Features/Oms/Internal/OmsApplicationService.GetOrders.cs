namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public PagedResult<OrderSummaryDto> GetOrders(OrderQuery query)
    {
        var tenantId = ResolveTenantId(query.TenantId);
        var page = Math.Max(1, query.Page);
        var pageSize = Math.Clamp(query.PageSize, 5, 100);
        var orders = _repository.Orders.Where(item => item.TenantId == tenantId);

        if (query.Status.HasValue)
        {
            orders = orders.Where(item => item.Status == query.Status.Value);
        }

        if (query.WarehouseId.HasValue)
        {
            orders = orders.Where(item => item.WarehouseId == query.WarehouseId.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.Search))
        {
            orders = orders.Where(item => MatchOrder(item, query.Search));
        }

        var ordered = orders.OrderByDescending(item => item.CreatedAt).ToList();
        var total = ordered.Count;
        var items = ordered.Skip((page - 1) * pageSize).Take(pageSize).Select(ToOrderSummaryDto).ToList();
        var totalPages = Math.Max(1, (int)Math.Ceiling(total / (double)pageSize));

        return new PagedResult<OrderSummaryDto>(items, page, pageSize, total, totalPages);
    }
}

