namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Common;

public sealed record ShipmentDto(
    Guid Id,
    Guid TenantId,
    string ShipmentCode,
    Guid OrderId,
    string OrderCode,
    string CustomerName,
    string CustomerPhone,
    string DeliveryAddress,
    Guid? DriverId,
    string DriverName,
    ShipmentStatus Status,
    string RouteName,
    string FailureReason,
    decimal CodAmount,
    DateTimeOffset UpdatedAt);


