
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<PickList> PickLists { get; }
    IReadOnlyList<Package> Packages { get; }
    PickList AddPickList(PickList pickList);
    Package AddPackage(Package package);
}

