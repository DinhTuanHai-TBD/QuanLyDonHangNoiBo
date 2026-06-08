namespace QuanLyDonHangNoiBo.Application.Features.Finance.Commands.Reconcile_Cod;

public sealed record ReconcileCodRequest(IReadOnlyList<Guid> CodCollectionIds, Guid? UserId);


