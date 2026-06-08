namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Common;

public sealed record PackageDto(
    Guid Id,
    Guid TenantId,
    Guid OrderId,
    string OrderCode,
    string PackageCode,
    decimal WeightKg,
    decimal LengthCm,
    decimal WidthCm,
    decimal HeightCm,
    string LabelUrl,
    PackageStatus Status,
    DateTimeOffset CreatedAt);


