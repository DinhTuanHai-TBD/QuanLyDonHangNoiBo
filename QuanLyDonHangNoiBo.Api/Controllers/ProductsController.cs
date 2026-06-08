using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ApiControllerBase
{
    public ProductsController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.ProductsManage)]
    public ActionResult<IReadOnlyList<ProductDto>> GetProducts([FromQuery] Guid? tenantId, [FromQuery] string? search)
    {
        return Execute(() => Service.GetProducts(tenantId, search));
    }

    [HttpGet("{productId:guid}")]
    [Authorize(Policy = PermissionPolicies.ProductsManage)]
    public ActionResult<ProductDto> GetProduct(Guid productId)
    {
        return Execute(() => Service.GetProduct(productId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.ProductsManage)]
    public ActionResult<ProductDto> CreateProduct(CreateProductRequest request)
    {
        return Execute(() => Service.CreateProduct(request));
    }

    [HttpPut("{productId:guid}")]
    [Authorize(Policy = PermissionPolicies.ProductsManage)]
    public ActionResult<ProductDto> UpdateProduct(Guid productId, UpdateProductRequest request)
    {
        return Execute(() => Service.UpdateProduct(productId, request));
    }

    [HttpDelete("{productId:guid}")]
    [Authorize(Policy = PermissionPolicies.ProductsManage)]
    public IActionResult DeleteProduct(Guid productId)
    {
        return Execute(() => Service.DeleteProduct(productId));
    }
}





