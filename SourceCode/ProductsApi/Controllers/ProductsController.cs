using Microsoft.AspNetCore.Mvc;
using ProductsApi.Services;
using Shared;

namespace ProductsApi.Controllers;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsService;

    public ProductsController(IProductsService productsService)
    {
        _productsService = productsService;
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _productsService.AddProduct(product); 

        return NoContent(); 
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productsService.DeleteProduct(id);

        return NoContent(); 
    }
}
