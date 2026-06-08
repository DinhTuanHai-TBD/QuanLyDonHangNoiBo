namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Commands.Update;

public sealed class UpdateTenantRequest
{
    public string Name { get; set; } = "";
    public string Plan { get; set; } = "Starter";
    public TenantStatus Status { get; set; } = TenantStatus.Active;
    public int UserLimit { get; set; } = 10;
    public int OrderLimit { get; set; } = 1000;
    public int WarehouseLimit { get; set; } = 1;
    public string DefaultLocale { get; set; } = "vi";
}


