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
    private int _userId;
    private readonly ApplicationDbContext _dbContext;
    public OrderService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task<bool> CreateOrderAsync(OrderCreate request)
    {
        double priceAsDouble = Convert.ToDouble(request.Price);
        var orderEntity = new OrderEntity
        {
            //Title = request.Title,
            Price = priceAsDouble,
            BuyerId = _userId,
            CreatedUtc = DateTime.Now,

        };
        _dbContext.Orders.Add(orderEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }
    //GetAllOrdersAsync is essentially same as GetAllOrdersByBuyer as check built-in
    //This becomes, in effect, a helper method, as the first steop in a GetAllOrdersByPurchaseDate???
    public async Task<IEnumerable<OrderListItem>> GetOrdersByArtistIdAsync(GetOrdersByArtistId request)
    // GetAllOrdersAsync().--> may be way to go in future
    {
        var orders = await _dbContext.Orders
        .Where(entity => entity.BuyerId == request.BuyerId && entity.ArtistId == request.ArtistId)
        .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            ArtistId = entity.ArtistId
        })
        .ToListAsync();
        return orders;
    }


    public async Task<IEnumerable<OrderListItem>> GetOrdersByProductIdAsync(int productId)
    // GetAllOrdersAsync().--> may be way to go in future
    {
        var orders = await _dbContext.Orders
        .Where(entity => entity.BuyerId == _userId && entity.ProductId == productId)
        .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            ProductId = entity.ProductId
        })
        .ToListAsync();
        return orders;
    }
    public async Task<IEnumerable<OrderListItem>> GetOrdersByPurchaseDateAsync(DateTime createdUtc)

    // GetAllOrdersAsync().--> may be way to go in future
    {
        var orders = await _dbContext.Orders
        .Where(entity => entity.BuyerId == _userId && entity.CreatedUtc == createdUtc)
        .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            CreatedUtc = entity.CreatedUtc
        })
        .ToListAsync();
        return orders;
    }

    public async Task<IEnumerable<OrderListItem>> GetAllOrdersAsync()
    {
        var orders = await _dbContext.Orders
        .Where(entity => entity.BuyerId == _userId)
        .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            CreatedUtc = entity.CreatedUtc
        })
        .ToListAsync();
        // .AsQueryable() --> may be way to go in future
        return orders;
    }

    public async Task<bool> UpdateOrderAsync(OrderUpdate request)
    {
        //Find the Order and validate it's owned by the user
        var orderEntity = await _dbContext.Orders.FindAsync(request.Id);

        //By using the null conditional operator we can check if it's null at the same time we check OwnerId
        if (orderEntity?.BuyerId != request.BuyerId)
            return false;

        //Now we update the entity's properties
        //Yet changing the Title means buying something else entirely, so...?
        // orderEntity.Title = request.Title;
        orderEntity.Price = request.Price;
        orderEntity.ModifiedUtc = DateTime.Now;

        //Save the changes to the database and capture how many rows were updated
        var numberOfChanges = await _dbContext.SaveChangesAsync();

        //numberofChnges is stated to be equal to 1 becausae only one row is updated
        return numberOfChanges == 1;
    }

    public async Task<OrderDetail> GetOrderDetailAsync(int orderId)
    {
        //Find the first order that has the given Id and an Owner Id that matches the requesting userId
        var orderEntity = await _dbContext.Orders.FirstOrDefaultAsync(e => e.Id == orderId && e.ArtistId == _userId);
        //If orderEntity is null then return null, otherwise initialize and return a new OrderDetail
        return orderEntity is null ? null : new OrderDetail
        {
            Id = orderEntity.Id,
            Price = orderEntity.Price,
            ProductId = orderEntity.ProductId,
            CreatedUtc = orderEntity.CreatedUtc,
            ModifiedUtc = orderEntity.ModifiedUtc
        };
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

    //Could add another helper method here to SearchById or one for SearchByPrice etc for use in other methods
}