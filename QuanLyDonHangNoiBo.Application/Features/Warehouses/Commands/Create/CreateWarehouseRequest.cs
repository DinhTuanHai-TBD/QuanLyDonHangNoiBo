namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Commands.Create;

public sealed class CreateWarehouseRequest
{
    public Guid? TenantId { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Province { get; set; } = "";
    public string Address { get; set; } = "";
    public bool IsActive { get; set; } = true;
}


