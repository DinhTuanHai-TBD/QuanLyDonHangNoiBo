namespace QuanLyDonHangNoiBo.Application.Features.Customers.Common;

public sealed record CustomerDto(Guid Id, Guid TenantId, string Code, string Name, string Phone, string Email, string Address, string Province, string Segment, string Note);


