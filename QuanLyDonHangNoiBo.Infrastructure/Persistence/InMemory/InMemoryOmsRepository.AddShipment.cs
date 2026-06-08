using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public Shipment AddShipment(Shipment shipment)
    {
        lock (_sync)
        {
            _shipments.Add(shipment);
        }

        return shipment;
    }
}



