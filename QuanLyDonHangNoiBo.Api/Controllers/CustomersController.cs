using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/customers")]
public sealed class CustomersController : ApiControllerBase
{
    public CustomersController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.CustomersManage)]
    public ActionResult<IReadOnlyList<CustomerDto>> GetCustomers([FromQuery] Guid? tenantId, [FromQuery] string? search)
    {
        return Execute(() => Service.GetCustomers(tenantId, search));
    }

    [HttpGet("{customerId:guid}")]
    [Authorize(Policy = PermissionPolicies.CustomersManage)]
    public ActionResult<CustomerDto> GetCustomer(Guid customerId)
    {
        return Execute(() => Service.GetCustomer(customerId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.CustomersManage)]
    public ActionResult<CustomerDto> CreateCustomer(CreateCustomerRequest request)
    {
        return Execute(() => Service.CreateCustomer(request));
    }

    [HttpPut("{customerId:guid}")]
    [Authorize(Policy = PermissionPolicies.CustomersManage)]
    public ActionResult<CustomerDto> UpdateCustomer(Guid customerId, UpdateCustomerRequest request)
    {
        return Execute(() => Service.UpdateCustomer(customerId, request));
    }

    [HttpDelete("{customerId:guid}")]
    [Authorize(Policy = PermissionPolicies.CustomersManage)]
    public IActionResult DeleteCustomer(Guid customerId)
    {
        return Execute(() => Service.DeleteCustomer(customerId));
    }
}





