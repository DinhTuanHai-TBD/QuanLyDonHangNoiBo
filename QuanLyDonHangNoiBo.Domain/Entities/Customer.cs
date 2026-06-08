using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Domain.Entities;

public sealed class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TenantId { get; set; }
    public string Code { get; set; } = "";
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public string Province { get; set; } = "";
    public string Segment { get; set; } = "Retail";
    public string Note { get; set; } = "";
}




