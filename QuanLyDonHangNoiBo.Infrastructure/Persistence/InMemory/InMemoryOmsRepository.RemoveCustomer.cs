using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public bool RemoveCustomer(Guid customerId)
    {
        lock (_sync)
        {
            var customer = _customers.FirstOrDefault(item => item.Id == customerId);
            return customer is not null && _customers.Remove(customer);
        }
    }
}



