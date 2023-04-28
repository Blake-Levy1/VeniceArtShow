using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class OrderService : IOrderService
{
    // private int _userId <--an earlier iteration utilized UserManager. We decided against this as indecipherable problems arose in Postman related to it.
    private readonly ApplicationDbContext _dbContext;
    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
        MarkProductAsSold(request.ProductId);
        return numberOfChanges == 1;
    }
    public async Task<IEnumerable<OrderListItem>> GetOrdersByArtistIdAsync(GetOrdersByBuyerOrArtistId request)
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
    public async Task<OrderDetail?> GetOrderDetailAsync(int orderId)
    {
        //Find the first order that has the given Id and an Owner Id that matches the requesting userId
        var orderEntity = await _dbContext.Orders
            .Include(x => x.Artist)
            .Include(x => x.Buyer)
            .FirstOrDefaultAsync(e =>
                e.Id == orderId);

        return orderEntity is null ? null : new OrderDetail
        {
            Id = orderEntity.Id,
            BuyerId = orderEntity.BuyerId,
            BuyerEmail = orderEntity.Buyer.Email,
            ProductId = orderEntity.ProductId,
            Artist = orderEntity.Artist.UserName,
            Price = orderEntity.Price,
            CreatedUtc = orderEntity.CreatedUtc,
        };
    }
    public async Task<bool> DeleteOrderAsync(int orderId)
    {
        var orderEntity = await _dbContext.Orders.FindAsync(orderId);
        return await _dbContext.SaveChangesAsync() == 1;
    }
    public async Task<bool> MarkProductAsSold(int productId)
    {
        ProductEntity productSold = await _dbContext.Products.FindAsync(productId);
        if (productSold != null)
        {
            productSold.IsSold = true;
            var numberOfChanges = await _dbContext.SaveChangesAsync();
            return numberOfChanges == 1;
        }
        return false;
    }

    // It was decided not to allow for Order Updates. They would be deleted instead.
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

}