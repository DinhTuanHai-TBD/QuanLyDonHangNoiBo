namespace QuanLyDonHangNoiBo.Application.Features.Warehouses.Commands.Update;

public sealed class UpdateWarehouseRequest
{
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Province { get; set; } = "";
    public string Address { get; set; } = "";
    public bool IsActive { get; set; } = true;
}


