using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class Tenant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Plan { get; set; } = "Starter";
    public TenantStatus Status { get; set; } = TenantStatus.Trial;
    public int UserLimit { get; set; }
    public int OrderLimit { get; set; }
    public int WarehouseLimit { get; set; }
    public string DefaultLocale { get; set; } = "vi";
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
}




