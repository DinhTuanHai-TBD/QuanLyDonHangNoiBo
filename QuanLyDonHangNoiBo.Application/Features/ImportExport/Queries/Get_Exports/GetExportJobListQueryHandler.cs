
namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Queries.Get_Exports;

public sealed class GetExportJobListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetExportJobListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<ExportJobDto> Handle(GetExportJobListQuery query)
    {
        return _service.GetExportJobs(query.TenantId);
    }
}


