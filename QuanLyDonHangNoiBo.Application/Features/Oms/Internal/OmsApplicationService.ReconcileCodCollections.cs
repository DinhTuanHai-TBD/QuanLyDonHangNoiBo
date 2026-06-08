namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<CodCollectionDto> ReconcileCodCollections(ReconcileCodRequest request)
    {
        var updated = new List<CodCollectionDto>();

        foreach (var id in request.CodCollectionIds.Distinct())
        {
            var collection = _repository.CodCollections.FirstOrDefault(item => item.Id == id)
                ?? throw new InvalidOperationException("Phieu COD khong ton tai.");

            collection.CollectedAmount = collection.CollectedAmount <= 0 ? collection.ExpectedAmount : collection.CollectedAmount;
            collection.Status = collection.CollectedAmount == collection.ExpectedAmount ? CodStatus.Reconciled : CodStatus.Mismatch;
            collection.ReconciledAt = DateTimeOffset.UtcNow;

            _repository.AddAuditLog(new AuditLog
            {
                TenantId = collection.TenantId,
                UserId = request.UserId,
                EntityName = nameof(CodCollection),
                EntityId = collection.Id.ToString(),
                Action = "ReconcileCOD",
                AfterValue = collection.Status.ToString()
            });

            updated.Add(ToCodDto(collection));
        }

        return updated;
    }
}

