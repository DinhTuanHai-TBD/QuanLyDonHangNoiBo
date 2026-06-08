using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class PickList
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public Guid OrderId { get; set; }
    public Guid WarehouseId { get; set; }
    public Guid? AssignedToUserId { get; set; }
    public string PickListCode { get; set; } = "";
    public PickListStatus Status { get; set; } = PickListStatus.Open;
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? CompletedAt { get; set; }
    public List<PickListItem> Items { get; set; } = [];
}




