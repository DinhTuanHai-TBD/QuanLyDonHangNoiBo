
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<AppUser> Users { get; }
    AppUser AddUser(AppUser user);
    bool RemoveUser(Guid userId);
}

