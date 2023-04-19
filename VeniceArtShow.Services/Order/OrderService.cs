using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
    public IEnumerable<OrderListWork> GetAllOrdersAsync()
    {

    }

    async Task<IEnumerable<OrderListWork>> IOrderService.GetAllOrdersAsync()
    {
        var orders = await _dbContext.Orders
        .Where(entity => entity.ArtistID == _userId)
        .Select(UserEntity => new OrderListWork
        {
            Id = entity.Id,
            Title = entity.Title,
            CreatedUtc = entity.CreatedUtc
        })
        .ToListAsync();
        return orders;

    }
}