using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

// [Authorize]
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly ITokenService _tokenService;
    private object _order;

    public OrderController(IOrderService orderService, ITokenService tokenService)
    {
        _orderService = orderService;
        _tokenService = tokenService;
    }
    //Post api/Order
    [HttpPost("Create")]
    public async Task<IActionResult> CreateOrder([FromBody] OrderCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        if (await _orderService.CreateOrderAsync(request))
            return Ok("Order created successfully.");

        return BadRequest("Order could not be created.");
    }
    //Get api/Order
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllOrders([FromBody] int buyerId)
    {
        var orders = await _orderService.GetAllOrdersAsync(buyerId);
        return Ok(orders);
    }

    // [Authorize]
    // [HttpGet("BuyerId")]
    // public async Task<IActionResult> GetOrderByBuyerId([FromBody] int buyerId)
    // {
    //     var userDetail = await _orderService.GetAllOrdersAsync(buyerId);
    //     if (userDetail is null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(userDetail);
    // }
    // [Authorize]
    [HttpGet("ArtistId")]
    public async Task<IActionResult> GetOrderByArtistId([FromBody] GetOrdersByBuyerOrArtistId request)
    {
        var userDetail = await _orderService.GetOrdersByArtistIdAsync(request);
        if (userDetail is null)
        {
            return NotFound();
        }
        return Ok(userDetail);
    }
    // [Authorize]
    [HttpGet("ProductId")]
    public async Task<IActionResult> GetOrdersByProductIdAsync([FromBody] int productId)
    {
        var userDetail = await _orderService.GetOrdersByProductIdAsync(productId);
        if (userDetail is null)
        {
            return BadRequest("Order not found. (Chaos results.)");
        }
        return Ok(userDetail);
    }
    [HttpGet("OrderId")]
    public async Task<IActionResult> GetOrdersByOrderIdAsync([FromBody] int orderId)
    {
        var userDetail = await _orderService.GetOrdersByOrderIdAsync(orderId);
        if (userDetail is null)
        {
            return BadRequest("Order not found. (Chaos results.)");
        }
        return Ok(userDetail);
    }

    // [Authorize(Policy = "Email")]
    [HttpGet("OrderDetail/{orderId:int}")]
    public async Task<IActionResult> GetOrderDetailAsync([FromRoute] int orderId, [FromBody] OrderDetailAuthorization authEmail)
    {
        var orderDetail = await _orderService.GetOrderDetailAsync(orderId);
        if (authEmail.AuthAdminEmail == "admin@veniceart.show")
        {
            return Ok(orderDetail);
        }
        return BadRequest("You are not authorized to see Order Details.");
    }

    //SearchByPurchaseDate moved to Stretch Goal to handle peculiarities of Time elements after MVP        
    // [HttpGet("CreatedUtc")]
    // public async Task<IActionResult> GetOrdersByPurchaseDate([FromBody] DateTime createdUtc)
    // {
    //     var userDetail = await _orderService.GetOrdersByPurchaseDateAsync(createdUtc);
    //     if (userDetail is null)
    //     {
    //         return NotFound();
    //     }
    //     return Ok(userDetail);
    // }

}
