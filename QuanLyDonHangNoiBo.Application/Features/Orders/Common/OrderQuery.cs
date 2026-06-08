namespace QuanLyDonHangNoiBo.Application.Features.Orders.Common;

public sealed class OrderQuery
{
    public Guid? TenantId { get; set; }
    public string? Search { get; set; }
    public OrderStatus? Status { get; set; }
    public Guid? WarehouseId { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}


