using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    // private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _dbContext;
    public ProductService(ApplicationDbContext dbContext)
    {
        
        // _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Include(x => x.Artist)
            .Include(x => x.Media)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Artist = entity.Artist.UserName,
                MediaType = entity.Media.MediaType,
                DateListed = entity.DateListed.ToString(),
                IsSold = entity.IsSold
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
            ArtistId = request.ArtistId,
            MediaId = request.MediaId,
            IsSold = false
        };

        _dbContext.Products.Add(productEntity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<ProductDetail?> GetProductByIdAsync(int productId)
    {
        // SetUserId();
        var productEntity = await _dbContext.Products
            .Include(x => x.Media)
            .Include(x => x.Artist)
            .FirstOrDefaultAsync(e =>
                e.Id == productId);

        return productEntity is null ? null : new ProductDetail
        {
            Id = productEntity.Id,
            Title = productEntity.Title,
            Artist = productEntity.Artist.UserName,
            ImageUrl = productEntity.ImageUrl,
            MediaType = productEntity.Media.MediaType,
            Description = productEntity.Description,
            Price = productEntity.Price,
            DateListed = productEntity.DateListed.ToString(),
            IsSold = productEntity.IsSold
        };
    }

    public async Task<bool> UpdateProductAsync (ProductUpdate request)
    {
        // SetUserId();
        double priceAsDouble = Convert.ToDouble(request.Price);
        var productEntity = await _dbContext.Products.FindAsync(request.Id);

        if (productEntity?.ArtistId != request.ArtistId)
            return false;

        productEntity.Title = request.Title;
        productEntity.ImageUrl = request.ImageUrl;
        productEntity.Description = request.Description;
        productEntity.Price = priceAsDouble;
        productEntity.MediaId = request.MediaId;
        
        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        // SetUserId();
        var productEntity = await _dbContext.Products.FindAsync(productId);

        _dbContext.Products.Remove(productEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByTitle(string productTitle)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Include(x => x.Artist)
            .Include(x => x.Media)
            .Where(entity => entity.Title == productTitle)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Artist = entity.Artist.UserName,
                MediaType = entity.Media.MediaType,
                DateListed = entity.DateListed.ToString(),
                IsSold = entity.IsSold
            })
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByMediaId(int mediaId)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Include(x => x.Artist)
            .Include(x => x.Media)
            .Where(entity => entity.MediaId == mediaId)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Artist = entity.Artist.UserName,
                MediaType = entity.Media.MediaType,
                DateListed = entity.DateListed.ToString(),
                IsSold = entity.IsSold
            })
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByPrice(SearchProductByPrice search)
    {
        // SetUserId();
        double lowPrice = Convert.ToDouble(search.LowPrice);
        double highPrice = Convert.ToDouble(search.HighPrice);
        var products = await _dbContext.Products
            .Include(x => x.Artist)
            .Include(x => x.Media)
            .Where(entity => entity.Price >= lowPrice && entity.Price <= highPrice)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Artist = entity.Artist.UserName,
                MediaType = entity.Media.MediaType,
                DateListed = entity.DateListed.ToString(),
                IsSold = entity.IsSold
            })
            .ToListAsync();
        return products;
    }

    public async Task<IEnumerable<ProductListItem>> SearchProductByArtistId(int artistId)
    {
        // SetUserId();
        var products = await _dbContext.Products
            .Include(x => x.Artist)
            .Include(x => x.Media)
            .Where(entity => entity.ArtistId == artistId)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                Artist = entity.Artist.UserName,
                MediaType = entity.Media.MediaType,
                DateListed = entity.DateListed.ToString(),
                IsSold = entity.IsSold
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
}