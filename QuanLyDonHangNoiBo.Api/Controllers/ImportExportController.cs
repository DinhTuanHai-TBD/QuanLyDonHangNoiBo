using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class ImportExportController : ApiControllerBase
{
    public ImportExportController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpPost("import/products")]
    [Authorize(Policy = PermissionPolicies.ImportProducts)]
    public ActionResult<ImportResultDto> ImportProducts(ImportProductsRequest request)
    {
        return Execute(() => Service.ImportProducts(request));
    }

    [HttpGet("exports")]
    [Authorize(Policy = PermissionPolicies.ReportsExport)]
    public ActionResult<IReadOnlyList<ExportJobDto>> GetExportJobs([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetExportJobs(tenantId));
    }

    [HttpPost("exports")]
    [HttpPost("reports/export")]
    [Authorize(Policy = PermissionPolicies.ReportsExport)]
    public ActionResult<ExportJobDto> CreateExportJob(CreateExportJobRequest request)
    {
        return Execute(() => Service.CreateExportJob(request));
    }
}





