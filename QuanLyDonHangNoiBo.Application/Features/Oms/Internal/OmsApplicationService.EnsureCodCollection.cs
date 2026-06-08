namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void EnsureCodCollection(Order order, decimal? collectedAmount)
    {
        if (order.PaymentMethod != PaymentMethod.Cod || _repository.CodCollections.Any(item => item.OrderId == order.Id))
        {
            return;
        }

        _repository.AddCodCollection(new CodCollection
        {
            TenantId = order.TenantId,
            OrderId = order.Id,
            DriverId = _repository.Shipments.FirstOrDefault(item => item.OrderId == order.Id)?.DriverId,
            ExpectedAmount = order.CodAmount,
            CollectedAmount = collectedAmount ?? order.CodAmount,
            Status = CodStatus.Collected,
            CollectedAt = DateTimeOffset.UtcNow
        });
    }
}

