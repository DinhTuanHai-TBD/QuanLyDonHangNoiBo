using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class CodCollection
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid? DriverId { get; set; }
    public decimal ExpectedAmount { get; set; }
    public decimal CollectedAmount { get; set; }
    public CodStatus Status { get; set; } = CodStatus.Pending;
    public DateTimeOffset? CollectedAt { get; set; }
    public DateTimeOffset? ReconciledAt { get; set; }
}




