namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private OrderSummaryDto ToOrderSummaryDto(Order order)
    {
        var customer = _repository.Customers.First(item => item.Id == order.CustomerId);
        var warehouse = _repository.Warehouses.First(item => item.Id == order.WarehouseId);
        return new OrderSummaryDto(order.Id, order.OrderCode, customer.Id, customer.Name, customer.Phone, warehouse.Id, warehouse.Code, order.Status, order.PaymentMethod, order.Total, order.CodAmount, order.CreatedAt, order.SlaDeadline);
    }
}

