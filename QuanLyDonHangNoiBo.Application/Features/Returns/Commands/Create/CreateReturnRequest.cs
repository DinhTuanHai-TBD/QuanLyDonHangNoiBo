namespace QuanLyDonHangNoiBo.Application.Features.Returns.Commands.Create;

public sealed class CreateReturnRequest
{
    public Guid? TenantId { get; set; }
    public Guid OrderId { get; set; }
    public string Reason { get; set; } = "";
    public decimal RefundAmount { get; set; }
}


