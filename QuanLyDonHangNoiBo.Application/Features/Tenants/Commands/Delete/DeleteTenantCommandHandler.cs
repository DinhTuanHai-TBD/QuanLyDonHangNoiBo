
namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Commands.Delete;

public sealed class DeleteTenantCommandHandler
{
    private readonly OmsApplicationService _service;

    public DeleteTenantCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public void Handle(DeleteTenantCommand command)
    {
        _service.DeleteTenant(command.TenantId);
    }
}


