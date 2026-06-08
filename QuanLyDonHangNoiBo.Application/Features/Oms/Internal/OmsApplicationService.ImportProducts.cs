namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ImportResultDto ImportProducts(ImportProductsRequest request)
    {
        var errors = new List<string>();
        var success = 0;
        foreach (var product in request.Products)
        {
            try
            {
                product.TenantId ??= request.TenantId;
                CreateProduct(product);
                success++;
            }
            catch (Exception ex) when (ex is InvalidOperationException or KeyNotFoundException)
            {
                errors.Add($"{product.Code}: {ex.Message}");
            }
        }

        return new ImportResultDto(success, errors.Count, errors);
    }
}

