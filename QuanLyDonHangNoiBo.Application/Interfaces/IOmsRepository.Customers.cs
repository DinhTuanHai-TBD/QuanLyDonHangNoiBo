
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<Customer> Customers { get; }
    Customer AddCustomer(Customer customer);
    bool RemoveCustomer(Guid customerId);
}

