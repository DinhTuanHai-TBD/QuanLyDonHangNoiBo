namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Common;

public sealed record PickListDto(
    Guid Id,
    Guid TenantId,
    Guid OrderId,
    string OrderCode,
    Guid WarehouseId,
    string WarehouseCode,
    Guid? AssignedToUserId,
    string AssignedToName,
    string PickListCode,
    PickListStatus Status,
    DateTimeOffset CreatedAt,
    DateTimeOffset? CompletedAt,
    IReadOnlyList<PickListItemDto> Items);


