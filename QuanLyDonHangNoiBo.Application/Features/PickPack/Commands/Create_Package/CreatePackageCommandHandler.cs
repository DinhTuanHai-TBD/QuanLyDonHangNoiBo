
namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Commands.Create_Package;

public sealed class CreatePackageCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreatePackageCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public PackageDto Handle(CreatePackageCommand command)
    {
        return _service.CreatePackage(command.Request);
    }
}


