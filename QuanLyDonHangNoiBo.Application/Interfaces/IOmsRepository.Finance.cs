
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<CodCollection> CodCollections { get; }
    CodCollection AddCodCollection(CodCollection codCollection);
}

