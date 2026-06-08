namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Common;

public sealed record PickListItemDto(Guid Id, Guid SkuId, string SkuCode, string Barcode, string ProductName, int RequiredQuantity, int PickedQuantity, bool IsCompleted);


