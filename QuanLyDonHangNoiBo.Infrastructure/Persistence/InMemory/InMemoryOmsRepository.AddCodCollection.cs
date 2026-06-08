using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public CodCollection AddCodCollection(CodCollection codCollection)
    {
        lock (_sync)
        {
            _codCollections.Add(codCollection);
        }

        return codCollection;
    }
}



