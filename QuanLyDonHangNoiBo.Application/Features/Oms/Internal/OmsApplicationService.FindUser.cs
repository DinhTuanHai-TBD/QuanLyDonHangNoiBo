namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private AppUser FindUser(Guid userId)
    {
        var user = _repository.Users.FirstOrDefault(item => item.Id == userId)
            ?? throw new KeyNotFoundException("User khong ton tai.");
        EnsureCanAccessTenant(user.TenantId);
        return user;
    }
}

