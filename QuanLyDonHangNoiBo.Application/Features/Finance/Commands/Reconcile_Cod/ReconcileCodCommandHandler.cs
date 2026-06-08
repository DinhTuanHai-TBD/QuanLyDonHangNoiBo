
namespace QuanLyDonHangNoiBo.Application.Features.Finance.Commands.Reconcile_Cod;

public sealed class ReconcileCodCommandHandler
{
    private readonly OmsApplicationService _service;

    public ReconcileCodCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<CodCollectionDto> Handle(ReconcileCodCommand command)
    {
        return _service.ReconcileCodCollections(command.Request);
    }
}


