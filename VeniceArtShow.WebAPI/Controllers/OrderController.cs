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
    //Post api/Order
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (await _orderService.CreateOrderAsync(request))
            return Ok("Order created successfully.");

        return BadRequest("order could not be created.");
    }

    // PUT api/Note
[HttpPut]
public async Task<IActionResult> UpdateNoteById([FromBody] OrderUpdate request)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

        return await _orderService.UpdateOrderAsync(request)
            ? Ok("Note updated successfullly.")
            : BadRequest("The Order could not be updated.");
}

    //Get api/Order
    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        return Ok(orders);
    }
}
