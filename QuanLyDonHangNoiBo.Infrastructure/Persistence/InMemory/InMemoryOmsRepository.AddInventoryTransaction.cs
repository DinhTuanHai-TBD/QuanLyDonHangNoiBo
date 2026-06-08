using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public InventoryTransaction AddInventoryTransaction(InventoryTransaction transaction)
    {
        lock (_sync)
        {
            _inventoryTransactions.Add(transaction);
        }

        return transaction;
    }
}



