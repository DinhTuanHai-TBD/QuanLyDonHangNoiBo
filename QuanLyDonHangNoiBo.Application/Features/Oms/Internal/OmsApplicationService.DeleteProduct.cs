namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public void DeleteProduct(Guid productId)
    {
        var product = FindProduct(productId);
        var skuIds = product.Skus.Select(item => item.Id).ToHashSet();
        if (_repository.Orders.Any(item => item.Items.Any(orderItem => skuIds.Contains(orderItem.SkuId))) ||
            _repository.InventoryTransactions.Any(item => skuIds.Contains(item.SkuId)))
        {
            throw new InvalidOperationException("Khong the xoa san pham da phat sinh don hang hoac giao dich kho. Hay chuyen IsActive=false.");
        }

        if (!_repository.RemoveProduct(product.Id))
        {
            throw new KeyNotFoundException("San pham khong ton tai.");
        }
    }
}

