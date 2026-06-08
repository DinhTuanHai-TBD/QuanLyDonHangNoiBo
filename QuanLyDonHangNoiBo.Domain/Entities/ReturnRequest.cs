using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class ReturnRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public string ReturnCode { get; set; } = "";
    public ReturnStatus Status { get; set; } = ReturnStatus.Requested;
    public string Reason { get; set; } = "";
    public decimal RefundAmount { get; set; }
    public Guid? ApprovedByUserId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
}




