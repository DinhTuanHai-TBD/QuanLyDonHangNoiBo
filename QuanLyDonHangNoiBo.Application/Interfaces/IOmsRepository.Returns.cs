
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<ReturnRequest> Returns { get; }
    ReturnRequest AddReturn(ReturnRequest returnRequest);
}

