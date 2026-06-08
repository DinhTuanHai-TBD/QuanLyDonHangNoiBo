namespace QuanLyDonHangNoiBo.Application.Features.Orders.Common;

public sealed record OrderDetailDto(
    Guid Id,
    Guid TenantId,
    string OrderCode,
    CustomerDto Customer,
    WarehouseDto Warehouse,
    OrderStatus Status,
    PaymentMethod PaymentMethod,
    decimal Discount,
    decimal ShippingFee,
    decimal CodAmount,
    decimal Subtotal,
    decimal Total,
    string DeliveryAddress,
    string InternalNote,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt,
    DateTimeOffset? SlaDeadline,
    IReadOnlyList<OrderItemDto> Items,
    IReadOnlyList<OrderHistoryDto> History);


