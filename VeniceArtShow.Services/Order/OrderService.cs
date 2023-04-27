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
    // private int _userId;
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
            // Title = request.Title,
            Price = request.Price,
            BuyerId = request.BuyerId,
            ArtistId = request.ArtistId,
            // MediaId = request.MediaId,
            ProductId = request.ProductId,
            CreatedUtc = DateTime.Now,

        };
        _dbContext.Orders.Add(orderEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

     //GetAllOrdersAsync is essentially same as GetAllOrdersByBuyer as check built-in
    //This becomes, in effect, a helper method, as the first steop in a GetAllOrdersByPurchaseDate???
    public async Task<IEnumerable<OrderListItem>> GetOrdersByArtistIdAsync(GetOrdersByBuyerOrArtistId request)
    // GetAllOrdersAsync().--> may be way to go in future
    {
        var orders = await _dbContext.Orders
            .Include(x => x.Buyer)
            .Include(x => x.Artist)
            .Include(x => x.Product)
            .Where(entity => entity.BuyerId == request.BuyerId && entity.ArtistId == request.ArtistId)
            .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            Buyer = entity.Buyer.UserName,
            Artist = entity.Artist.UserName,
            Product = entity.Product.Title,
            CreatedUtc = entity.CreatedUtc.ToString()
        })
        .ToListAsync();
        return orders;
    }


    public async Task<IEnumerable<OrderListItem>> GetOrdersByOrderIdAsync(int orderId)
    // GetAllOrdersAsync().--> may be way to go in future
    {
        var orders = await _dbContext.Orders
            .Include(x => x.Buyer)
            .Include(x => x.Artist)
            .Include(x => x.Product)
            .Where(entity => entity.Id == orderId)
            .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            Buyer = entity.Buyer.UserName,
            Artist = entity.Artist.UserName,
            Product = entity.Product.Title,
            CreatedUtc = entity.CreatedUtc.ToString()
        })
        .ToListAsync();
        return orders;
    }

    public async Task<IEnumerable<OrderListItem>> GetOrdersByProductIdAsync(int productId)
    // GetAllOrdersAsync().--> may be way to go in future
    {
        var orders = await _dbContext.Orders
            .Include(x => x.Buyer)
            .Include(x => x.Artist)
            .Include(x => x.Product)
            .Where(entity => entity.ProductId == productId)
            .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            Buyer = entity.Buyer.UserName,
            Artist = entity.Artist.UserName,
            Product = entity.Product.Title,
            CreatedUtc = entity.CreatedUtc.ToString()
        })
        .ToListAsync();
        return orders;
    }

    // public async Task<IEnumerable<OrderListItem>> GetOrdersByPurchaseDateAsync(DateTime createdUtc)
    // {
    //     var orders = await _dbContext.Orders
    //     // .Where(entity => entity.BuyerId == _userId && entity.CreatedUtc == createdUtc)
    //     .Select(entity => new OrderListItem
    //     {
    //         Id = entity.Id,
    //         ArtistId = entity.ArtistId,
    //         CreatedUtc = entity.CreatedUtc
    //     })
    //     .ToListAsync();
    //     return orders;
    // }

    //Currently "GetAllOrdersAsync" is pulling by the buyer id passed in. Not all orders in the database as a whole. Our vision is to have the buyer driving the requests. If we were to add another method to pull ALL orders in database, we could do a "GetAllOrdersByAllBuyers"
    public async Task<IEnumerable<OrderListItem>> GetAllOrdersAsync(int buyerId)
    {
        var orders = await _dbContext.Orders
            .Include(x => x.Buyer)
            .Include(x => x.Artist)
            .Include(x => x.Product)
            .Where(entity => entity.BuyerId == buyerId)
            .Select(entity => new OrderListItem
        {
            Id = entity.Id,
            Buyer = entity.Buyer.UserName,
            Artist = entity.Artist.UserName,
            Product = entity.Product.Title,
            CreatedUtc = entity.CreatedUtc.ToString()
        })
        .ToListAsync();
        // .AsQueryable() --> may be way to go in future
        return orders;
    }

    // public async Task<bool> UpdateOrderAsync(OrderUpdate request)
    // {
    //     //Find the Order and validate it's owned by the user
    //     var orderEntity = await _dbContext.Orders.FindAsync(request.Id);

    //     //By using the null conditional operator we can check if it's null at the same time we check OwnerId
    //     if (orderEntity?.BuyerId != request.BuyerId)
    //         return false;

    //     //Now we update the entity's properties
    //     //Yet changing the Title means buying something else entirely, so...?
    //     // orderEntity.Title = request.Title;
    //     // orderEntity.Artist = request.Artist;
    //     // orderEntity.Price = request.Price;
    //     orderEntity.ModifiedUtc = DateTime.Now;

    //     //Save the changes to the database and capture how many rows were updated
    //     var numberOfChanges = await _dbContext.SaveChangesAsync();

    //     //numberofChnges is stated to be equal to 1 becausae only one row is updated
    //     return numberOfChanges == 1;
    // }

    public async Task<OrderDetail> GetOrderDetailAsync(int orderId)
    {
            //Find the first order that has the given Id and an Owner Id that matches the requesting userId
        var orderEntity = await _dbContext.Orders
            .Include(x => x.Artist)
            .Include(x => x.Buyer)
            .FirstOrDefaultAsync(e =>
                e.Id == orderId);

        return orderEntity is null ? null : new OrderDetail 
        // var OrderEntity = await _dbContext.Orders.FirstOrDefaultAsync(predicate: e=>
        //     e.Id == orderId && e.BuyerId == buyerId);

        // (e => e.Id == orderId && e.ArtistId == artistId);
        //If orderEntity is null then return null, otherwise initialize and return a new OrderDetail

        {
            Id = orderEntity.Id,
            BuyerId = orderEntity.BuyerId,
            BuyerEmail = orderEntity.Buyer.Email,
            ProductId = orderEntity.ProductId,
            Artist = orderEntity.Artist.UserName,
            // MediaId = orderEntity.MediaId,
            Price = orderEntity.Price,
            CreatedUtc = orderEntity.CreatedUtc,
            // ModifiedUtc = orderEntity.ModifiedUtc
        };
    }

    public async Task<bool> DeleteOrderAsync(int orderId)
    {
        //Find the Order by the given Id
        var orderEntity = await _dbContext.Orders.FindAsync(orderId);
        //Validate the Order exists and is owned by the user
        // if (OrderEntity?.BuyerId != _userId)
        //     return false;
        //Remove the Order from the DbContext and asasert that the one change was saved
        _dbContext.Orders.Remove(orderEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }
}