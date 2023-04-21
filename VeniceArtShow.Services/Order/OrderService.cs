using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _userId;
    private readonly ApplicationDbContext _dbContext;
    public OrderService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;
        
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
        .Where(entity => entity.BuyerId == _userId)
        .Select(entity => new OrderListWork
        {
            Id = entity.Id,
            Title = entity.Title,
            CreatedUtc = entity.CreatedUtc
        })
        .ToListAsync();
        return orders;

    }

    Task<OrderDetail> IOrderService.GetOrderByIdAsync(int orderId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteOrderAsync(int OrderId)
    {
        //Find the Order by the given Id
        var OrderEntity = await _dbContext.Orders.FindAsync(OrderId);
        //Validate the Order exists and is owned by the user
        if (OrderEntity?.BuyerId != _userId)
            return false;
        //Remove the Order from the DbContext and asasert that the one change was saved
        _dbContext.Orders.Remove(OrderEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }
    private void SetUserId()
    {
        var userClaims = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var value = userClaims.FindFirst("Id")?.Value;
        // var validId = int.TryParse(value, out _userId);
        if (value == null)
            throw new Exception("Attempted to create an Order without a valid User.");
        else 
        {
            _userId = value;
        }
            
    }
}