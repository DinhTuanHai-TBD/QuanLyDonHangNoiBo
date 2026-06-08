namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private CodCollectionDto ToCodDto(CodCollection collection)
    {
        var order = _repository.Orders.First(item => item.Id == collection.OrderId);
        var customer = _repository.Customers.First(item => item.Id == order.CustomerId);
        var driver = collection.DriverId.HasValue ? _repository.Users.FirstOrDefault(item => item.Id == collection.DriverId.Value) : null;
        return new CodCollectionDto(collection.Id, order.Id, order.OrderCode, customer.Name, driver?.FullName ?? "Chua gan", collection.ExpectedAmount, collection.CollectedAmount, collection.Status, collection.CollectedAt, collection.ReconciledAt);
    }
}

