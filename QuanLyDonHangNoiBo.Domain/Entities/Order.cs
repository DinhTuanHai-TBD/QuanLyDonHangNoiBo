using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public string OrderCode { get; set; } = "";
    public Guid CustomerId { get; set; }
    public Guid WarehouseId { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Draft;
    public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cod;
    public decimal Discount { get; set; }
    public decimal ShippingFee { get; set; }
    public decimal CodAmount { get; set; }
    public string DeliveryAddress { get; set; } = "";
    public string InternalNote { get; set; } = "";
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? SlaDeadline { get; set; }
    public List<OrderItem> Items { get; set; } = [];
    public decimal Subtotal => Items.Sum(item => item.LineTotal);
    public decimal Total => Math.Max(0, Subtotal - Discount + ShippingFee);
}




