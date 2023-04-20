using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    //Get api/Order
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }

    //Post api/Order
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (await _orderService.CreateOrderAsync(request))
            return Ok("Order created successfully.");

        return BadRequest("Note could not be created.");
    }

    // public async Task<OrderDetail> GetOrderDetailAsync(int orderId)
    // {
    //     //Find the first note that has the given Id and an Owner Id that matches the requesting userId
    //     var orderEntity = await _dbContext.Orders.FirstOrDefaultAsync(e => e.Id == orderId && e.ArtistId = userId);
    //     //If orderEntity is null then return null, otherwise initialize and return a new OrderDtail
    //     {
    //         Id = orderEntity.Id,
    //         Title = orderEntity.Title,
    //         Price = orderEntity.Price,
    //         CreatedUtc = orderEntity.CreatedUtc,
    //         ModifiedUTC = orderEntity.ModifedUtc
    //     }
}
