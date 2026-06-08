using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    private int StockFor(string skuCode, string warehouseCode)
    {
        return (skuCode, warehouseCode) switch
        {
            ("SKU-BOT-750", "HN-01") => 5,
            ("SKU-TEA-BOX", "DN-01") => 7,
            ("SKU-SNK-CASHEW", "HCM-01") => 12,
            ("SKU-COF-250", "HN-01") => 80,
            ("SKU-COF-500", "HCM-01") => 64,
            _ => 32
        };
    }
}



