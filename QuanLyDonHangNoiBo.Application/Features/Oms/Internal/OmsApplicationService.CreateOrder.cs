namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public OrderDetailDto CreateOrder(CreateOrderRequest request)
    {
        var tenantId = ResolveTenantId(request.TenantId);
        var customer = _repository.Customers.FirstOrDefault(item => item.Id == request.CustomerId && item.TenantId == tenantId)
            ?? throw new InvalidOperationException("Khach hang khong ton tai.");
        var warehouse = _repository.Warehouses.FirstOrDefault(item => item.Id == request.WarehouseId && item.TenantId == tenantId)
            ?? throw new InvalidOperationException("Kho khong ton tai.");

        if (request.Items.Count == 0)
        {
            throw new InvalidOperationException("Don hang can co it nhat mot SKU.");
        }

        var orderNumber = _repository.Orders.Count(item => item.TenantId == tenantId) + 1;
        var order = new Order
        {
            TenantId = tenantId,
            OrderCode = $"ORD-{DateTimeOffset.UtcNow:yyMMdd}-{orderNumber:0000}",
            CustomerId = customer.Id,
            WarehouseId = warehouse.Id,
            PaymentMethod = request.PaymentMethod,
            Discount = Math.Max(0, request.Discount),
            ShippingFee = Math.Max(0, request.ShippingFee),
            DeliveryAddress = string.IsNullOrWhiteSpace(request.DeliveryAddress) ? customer.Address : request.DeliveryAddress.Trim(),
            InternalNote = request.InternalNote.Trim(),
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
            SlaDeadline = DateTimeOffset.UtcNow.AddHours(36)
        };

        foreach (var item in request.Items)
        {
            if (item.Quantity <= 0)
            {
                throw new InvalidOperationException("So luong SKU phai lon hon 0.");
            }

            var sku = _repository.Skus.FirstOrDefault(skuItem => skuItem.Id == item.SkuId && skuItem.TenantId == tenantId)
                ?? throw new InvalidOperationException("SKU khong ton tai.");
            var product = _repository.Products.First(productItem => productItem.Id == sku.ProductId);

            order.Items.Add(new OrderItem
            {
                OrderId = order.Id,
                SkuId = sku.Id,
                SkuCode = sku.SkuCode,
                ProductName = $"{product.Name} - {sku.Name}",
                Quantity = item.Quantity,
                UnitPrice = sku.Price
            });
        }

        order.CodAmount = request.CodAmount > 0 ? request.CodAmount : order.Total;

        _repository.AddOrder(order);
        _repository.AddOrderStatusHistory(new OrderStatusHistory
        {
            TenantId = tenantId,
            OrderId = order.Id,
            OldStatus = OrderStatus.Draft,
            NewStatus = OrderStatus.Draft,
            Note = "Create order"
        });
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = tenantId,
            EntityName = nameof(Order),
            EntityId = order.Id.ToString(),
            Action = "CreateOrder",
            AfterValue = order.OrderCode
        });
        _repository.AddNotification(new NotificationItem
        {
            TenantId = tenantId,
            Title = "Don hang moi",
            Message = $"{order.OrderCode} vua duoc tao tu kenh noi bo.",
            Severity = NotificationSeverity.Info,
            Link = $"/orders/{order.Id}"
        });

        return ToOrderDetailDto(order);
    }
}

