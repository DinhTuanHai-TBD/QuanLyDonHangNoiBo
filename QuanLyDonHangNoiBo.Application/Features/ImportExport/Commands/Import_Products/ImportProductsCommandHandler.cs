
namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Commands.Import_Products;

public sealed class ImportProductsCommandHandler
{
    private readonly OmsApplicationService _service;

    public ImportProductsCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ImportResultDto Handle(ImportProductsCommand command)
    {
        return _service.ImportProducts(command.Request);
    }
}


