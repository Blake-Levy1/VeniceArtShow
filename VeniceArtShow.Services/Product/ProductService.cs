using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly int _userId;
    private readonly ApplicationDbContext _dbContext;
    public ProductService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
    {
        var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
        var value = userClaims.FindFirst("Id")?.Value;
        var validId = int.TryParse(value, out _userId);
        if (!validId)
        {
            throw new Exception("Attempted to build ProductService without Id Claim.");
        }
        
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ProductListItem>> GetAllProductsAsync()
    {
        var products = await _dbContext.Products
            .Where(entity => entity.Id == _userId)
            .Select(entity => new ProductListItem
            {
                Id = entity.Id,
                Title = entity.Title,
                DateListed = entity.DateListed
            })
            .ToListAsync();

        return products;
    }
}