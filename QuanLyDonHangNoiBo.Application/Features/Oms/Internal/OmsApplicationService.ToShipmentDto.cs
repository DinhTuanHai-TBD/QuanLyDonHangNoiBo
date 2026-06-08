namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private ShipmentDto ToShipmentDto(Shipment shipment)
    {
        var order = _repository.Orders.First(item => item.Id == shipment.OrderId);
        var customer = _repository.Customers.First(item => item.Id == order.CustomerId);
        var driver = shipment.DriverId.HasValue ? _repository.Users.FirstOrDefault(item => item.Id == shipment.DriverId.Value) : null;
        return new ShipmentDto(shipment.Id, shipment.TenantId, shipment.ShipmentCode, order.Id, order.OrderCode, customer.Name, customer.Phone, order.DeliveryAddress, shipment.DriverId, driver?.FullName ?? "Chua gan", shipment.Status, shipment.RouteName, shipment.FailureReason, order.CodAmount, shipment.UpdatedAt);
    }
}

