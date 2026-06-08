namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Create;

public sealed class CreateOrderRequest
{
    public Guid? TenantId { get; set; }
    public Guid CustomerId { get; set; }
    public Guid WarehouseId { get; set; }
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cod;
    public decimal Discount { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal CodAmount { get; set; }
    public string DeliveryAddress { get; set; } = "";
    public string InternalNote { get; set; } = "";
    public IReadOnlyList<CreateOrderItemRequest> Items { get; set; } = [];
}


