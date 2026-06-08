using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public ProofOfDelivery AddProofOfDelivery(ProofOfDelivery proofOfDelivery)
    {
        lock (_sync)
        {
            _proofOfDeliveries.Add(proofOfDelivery);
        }

        return proofOfDelivery;
    }
}



