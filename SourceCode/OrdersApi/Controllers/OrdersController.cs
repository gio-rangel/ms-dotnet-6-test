using Microsoft.AspNetCore.Mvc;
using OrdersApi.Services;
using Shared;

namespace OrdersApi.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _ordersService;

    public OrdersController(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    [HttpGet]
    [Route("start-consuming-service")]
    public async Task<IActionResult> StartConsumingService()
    {
        await _ordersService.StartConsumingService();

        return NoContent(); 
    }

    [HttpGet]
    [Route("get-products")]
    public IActionResult GetProduct() 
    {
        var product = _ordersService.GetProducts();

        return Ok(product);
    }

    [HttpPost]
    [Route("add-order")]
    public IActionResult AddOrder(Order order) 
    {
        _ordersService.AddOrder(order); 

        return Ok("Order placed");
    }

    [HttpGet]
    [Route("get-order-summary")]
    public IActionResult GetOrderSummary() => Ok(_ordersService.GetOrdersSummary());
}
