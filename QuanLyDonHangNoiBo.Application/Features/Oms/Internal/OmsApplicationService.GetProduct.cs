namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ProductDto GetProduct(Guid productId)
    {
        return ToProductDto(FindProduct(productId));
    }
}

