using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

public interface IProductService
{
    Task<bool> CreateProductAsync(ProductCreate request);
    Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
    Task<ProductDetail> GetProductByIdAsync(int productId);
}