using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public bool RemoveUser(Guid userId)
    {
        lock (_sync)
        {
            var user = _users.FirstOrDefault(item => item.Id == userId);
            return user is not null && _users.Remove(user);
        }
    }
}



