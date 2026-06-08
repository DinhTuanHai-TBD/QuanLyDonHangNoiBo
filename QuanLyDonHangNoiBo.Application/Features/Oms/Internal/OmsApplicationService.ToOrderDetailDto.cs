namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private OrderDetailDto ToOrderDetailDto(Order order)
    {
        var customer = _repository.Customers.First(item => item.Id == order.CustomerId);
        var warehouse = _repository.Warehouses.First(item => item.Id == order.WarehouseId);
        var history = _repository.OrderStatusHistories
            .Where(item => item.OrderId == order.Id)
            .OrderBy(item => item.ChangedAt)
            .Select(item => new OrderHistoryDto(item.OldStatus, item.NewStatus, item.Note, item.ChangedAt))
            .ToList();

        var items = order.Items
            .Select(item => new OrderItemDto(item.Id, item.SkuId, item.SkuCode, item.ProductName, item.Quantity, item.UnitPrice, item.LineTotal))
            .ToList();

        return new OrderDetailDto(order.Id, order.TenantId, order.OrderCode, ToCustomerDto(customer), ToWarehouseDto(warehouse), order.Status, order.PaymentMethod, order.Discount, order.ShippingFee, order.CodAmount, order.Subtotal, order.Total, order.DeliveryAddress, order.InternalNote, order.CreatedAt, order.UpdatedAt, order.SlaDeadline, items, history);
    }
}

