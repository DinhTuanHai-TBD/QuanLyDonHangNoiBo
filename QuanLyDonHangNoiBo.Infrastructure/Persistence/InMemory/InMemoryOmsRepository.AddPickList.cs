using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public PickList AddPickList(PickList pickList)
    {
        lock (_sync)
        {
            _pickLists.Add(pickList);
        }

        return pickList;
    }
}



