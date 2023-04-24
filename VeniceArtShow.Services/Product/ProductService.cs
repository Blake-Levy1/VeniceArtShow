using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private int _userId;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _dbContext;
    public ProductService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
    {
        // SetUserId();
        var products = await _dbContext.Products
            // .Where(entity => entity.ArtistId == _userId)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                DateListed = entity.DateListed
            })
            .ToListAsync();

        return products;
    }

    public async Task<bool> CreateProductAsync(ProductCreate request)
    {
        // SetUserId();
        var productEntity = new ProductEntity
        {
            Title = request.Title,
            ImageUrl = request.ImageUrl,
            Description = request.Description,
            Price = request.Price,
            DateListed = DateTime.Now,
            ArtistId = _userId,
            MediaId = request.MediaId
        };

        _dbContext.Products.Add(productEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<ProductDetail> GetProductByIdAsync(int productId)
    {
        // SetUserId();
        var productEntity = await _dbContext.Products.Include(x => x.Media)
            .FirstOrDefaultAsync(e =>
                e.Id == productId && e.ArtistId == _userId
            );

        return productEntity is null ? null : new ProductDetail
        {
            Id = productEntity.Id,
            Title = productEntity.Title,
            ImageUrl = productEntity.ImageUrl,
            Description = productEntity.Description,
            Price = productEntity.Price,
            DateListed = DateTime.Now,
            MediaId = productEntity.MediaId
            // Media = productEntity.Media
        };
    }

    public async Task<bool> UpdateProductAsync (ProductUpdate request)
    {
        // SetUserId();
        var productEntity = await _dbContext.Products.FindAsync(request.Id);

        if (productEntity?.ArtistId != _userId)
            return false;

        productEntity.Title = request.Title;
        productEntity.ImageUrl = request.ImageUrl;
        productEntity.Description = request.Description;
        productEntity.Price = request.Price;
        productEntity.MediaId = request.MediaId;

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        // SetUserId();
        var productEntity = await _dbContext.Products.FindAsync(productId);

        if (productEntity?.ArtistId != _userId)
            return false;

        _dbContext.Products.Remove(productEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByTitle(string productTitle)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Where(entity => entity.Title == productTitle)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                DateListed = entity.DateListed
            })
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByMediaId(int mediaId)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Where(entity => entity.MediaId == mediaId)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                DateListed = entity.DateListed
            })
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByPrice(double lowPrice, double highPrice)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Where(entity => entity.Price <= lowPrice && entity.Price >= highPrice)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                DateListed = entity.DateListed
            })
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByArtistId(int artistId)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Where(entity => entity.ArtistId == artistId)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                DateListed = entity.DateListed
            })
            .ToListAsync();
        return products;
    }

    // private void SetUserId()
    // {
    //     var userClaims = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
    //     var value = userClaims.FindFirst("Id")?.Value;
    //     var validId = int.TryParse(value, out _userId);
    //     if (value is null)
    //     {
    //         throw new Exception("Attempted to build ProductService without Id Claim.");
    //     }
    //     // } else 
    //     // {
    //     //     _userId = value;
    //     // }
    // }

//     public static Guid ToGuid(int userId)
//     {
//         byte[] bytes = new byte[16];
//         BitConverter.GetBytes(userId).CopyTo(bytes, 0);
//         return new Guid(bytes);
//     }
}