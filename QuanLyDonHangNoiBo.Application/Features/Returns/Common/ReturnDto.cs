namespace QuanLyDonHangNoiBo.Application.Features.Returns.Common;

public sealed record ReturnDto(
    Guid Id,
    Guid TenantId,
    Guid OrderId,
    string OrderCode,
    string CustomerName,
    string ReturnCode,
    ReturnStatus Status,
    string Reason,
    decimal RefundAmount,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);


