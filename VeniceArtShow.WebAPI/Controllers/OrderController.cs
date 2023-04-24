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
    private readonly ITokenService _tokenService;
    public OrderController(IOrderService orderService, ITokenService tokenService)
    {
        _orderService = orderService;
        _tokenService = tokenService;
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

    // [Authorize]
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetOrderByBuyerId([FromRoute] int buyerId)
    {
        var userDetail = await _orderService.GetAllOrdersAsync();
        if (userDetail is null)
        {
            return NotFound();
        }
        return Ok(userDetail);
    }
    // [Authorize]
    [HttpGet("{userId:string}")]
    public async Task<IActionResult> GetOrderByArtistId([FromRoute] string artistId)
    {
        var userDetail = await _orderService.GetOrdersByArtistIdAsync(artistId);
        if (userDetail is null)
        {
            return NotFound();
        }
        return Ok(userDetail);
        }
        // [Authorize]
        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetOrdersByProductIdAsync([FromRoute] int productId)
        {
            var userDetail = await _orderService.GetOrdersByProductIdAsync(productId);
            if (userDetail is null)
            {
                return BadRequest("Order not found. (Chaos results.)");
            }
            return Ok(userDetail);
        }
        // [Authorize]
        [HttpGet("{userId:DateTime}")]
        public async Task<IActionResult> GetOrdersByPurchaseDate(DateTime createdUtc)
        {
            var userDetail = await _orderService.GetOrdersByPurchaseDateAsync(createdUtc);
            if (userDetail is null)
            {
                return NotFound();
            }
            return Ok(userDetail);
        }

        [HttpPost("~/api/Token")]
        public async Task<IActionResult> Token([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tokenResponse = await _tokenService.GetTokenAsync(request);
            if (tokenResponse is null)
                return BadRequest("Invalid username or password.");
            return Ok(tokenResponse);
        }

    }
