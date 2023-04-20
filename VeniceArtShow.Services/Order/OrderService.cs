using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly int _userId;
    private readonly ApplicationDbContext _dbContext;
    public OrderService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    {
        var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var value = userClaims.FindFirst("Id")?.Value;
        var validId = int.TryParse(value, out _userId);
        if (!validId)
            throw new Exception("Attempted to create an Order without a valid User."
            );
        _dbContext = dbContext;
    }
    public async Task<bool> CreateOrderAsync(OrderCreate request)
    {
        var orderEntity = new OrderEntity
        {
            //Title = request.Title,
            Price = request.Price,
            BuyerId = _userId,
            //CreatedUtc = DateTimeOffset.Now,

        };
        _dbContext.Orders.Add(orderEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<IEnumerable<OrderListWork>> GetAllOrdersAsync()
    {
        var orders = await _dbContext.Orders
        .Where(entity => entity.Id == _userId)
        .Select(entity => new OrderListWork
        {
            Id = entity.Id,
            Title = entity.Title,
            CreatedUtc = entity.CreatedUtc
        })
        .ToListAsync();
        return orders;

    }

    public Task<OrderDetail> GetOrderByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    // Task<OrderDetail> IOrderService.GetOrderByIdAsync(int orderId)
    // {
    //     throw new NotImplementedException();
    // }
}