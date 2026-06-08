namespace QuanLyDonHangNoiBo.Application.Features.Orders.Common;

public sealed record OrderItemDto(Guid Id, Guid SkuId, string SkuCode, string ProductName, int Quantity, decimal UnitPrice, decimal LineTotal);


