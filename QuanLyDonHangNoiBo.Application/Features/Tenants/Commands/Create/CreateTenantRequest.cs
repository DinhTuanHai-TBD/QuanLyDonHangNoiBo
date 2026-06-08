namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Commands.Create;

public sealed class CreateTenantRequest
{
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Plan { get; set; } = "Starter";
    public TenantStatus Status { get; set; } = TenantStatus.Trial;
    public int UserLimit { get; set; } = 10;
    public int OrderLimit { get; set; } = 1000;
    public int WarehouseLimit { get; set; } = 1;
    public string DefaultLocale { get; set; } = "vi";
}


