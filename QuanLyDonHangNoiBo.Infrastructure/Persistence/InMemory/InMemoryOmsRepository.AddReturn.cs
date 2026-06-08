using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public ReturnRequest AddReturn(ReturnRequest returnRequest)
    {
        lock (_sync)
        {
            _returns.Add(returnRequest);
        }

        return returnRequest;
    }
}



