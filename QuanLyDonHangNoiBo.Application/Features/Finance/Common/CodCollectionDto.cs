namespace QuanLyDonHangNoiBo.Application.Features.Finance.Common;

public sealed record CodCollectionDto(
    Guid Id,
    Guid OrderId,
    string OrderCode,
    string CustomerName,
    string DriverName,
    decimal ExpectedAmount,
    decimal CollectedAmount,
    CodStatus Status,
    DateTimeOffset? CollectedAt,
    DateTimeOffset? ReconciledAt);


