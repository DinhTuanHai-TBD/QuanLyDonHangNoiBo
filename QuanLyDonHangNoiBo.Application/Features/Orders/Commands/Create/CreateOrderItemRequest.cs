namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Create;

public sealed class CreateOrderItemRequest
{
    public Guid SkuId { get; set; }
    public int Quantity { get; set; }
}


