namespace QuanLyDonHangNoiBo.Application.Features.Customers.Commands.Update;

public sealed class UpdateCustomerRequest
{
    public string Name { get; set; } = "";
    public string Phone { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public string Province { get; set; } = "";
    public string Segment { get; set; } = "Retail";
    public string Note { get; set; } = "";
}


