using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public InventoryStock AddInventoryStock(InventoryStock stock)
    {
        lock (_sync)
        {
            _inventoryStocks.Add(stock);
        }

        return stock;
    }
}



