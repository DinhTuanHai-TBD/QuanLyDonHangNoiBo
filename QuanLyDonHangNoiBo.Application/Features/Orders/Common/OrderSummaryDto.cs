namespace QuanLyDonHangNoiBo.Application.Features.Orders.Common;

public sealed record OrderSummaryDto(
    Guid Id,
    string OrderCode,
    Guid CustomerId,
    string CustomerName,
    string CustomerPhone,
    Guid WarehouseId,
    string WarehouseCode,
    OrderStatus Status,
    PaymentMethod PaymentMethod,
    decimal Total,
    decimal CodAmount,
    DateTimeOffset CreatedAt,
    DateTimeOffset? SlaDeadline);


