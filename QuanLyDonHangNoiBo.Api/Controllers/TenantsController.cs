using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/tenants")]
public sealed class TenantsController : ApiControllerBase
{
    public TenantsController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.TenantsManage)]
    public ActionResult<IReadOnlyList<TenantDto>> GetTenants()
    {
        return Execute(Service.GetTenants);
    }

    [HttpGet("{tenantId:guid}")]
    [Authorize(Policy = PermissionPolicies.TenantsManage)]
    public ActionResult<TenantDto> GetTenant(Guid tenantId)
    {
        return Execute(() => Service.GetTenant(tenantId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.TenantsManage)]
    public ActionResult<TenantDto> CreateTenant(CreateTenantRequest request)
    {
        return Execute(() => Service.CreateTenant(request));
    }

    [HttpPut("{tenantId:guid}")]
    [Authorize(Policy = PermissionPolicies.TenantsManage)]
    public ActionResult<TenantDto> UpdateTenant(Guid tenantId, UpdateTenantRequest request)
    {
        return Execute(() => Service.UpdateTenant(tenantId, request));
    }

    [HttpDelete("{tenantId:guid}")]
    [Authorize(Policy = PermissionPolicies.TenantsManage)]
    public IActionResult DeleteTenant(Guid tenantId)
    {
        return Execute(() => Service.DeleteTenant(tenantId));
    }
}





