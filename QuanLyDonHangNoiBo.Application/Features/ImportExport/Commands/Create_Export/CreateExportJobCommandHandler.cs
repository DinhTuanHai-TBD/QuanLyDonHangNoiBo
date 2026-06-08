
namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Commands.Create_Export;

public sealed class CreateExportJobCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateExportJobCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ExportJobDto Handle(CreateExportJobCommand command)
    {
        return _service.CreateExportJob(command.Request);
    }
}


