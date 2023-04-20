using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

public interface IProductService
{
    Task<bool> CreateProductAsync(ProductCreate request);
    Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
    Task<bool> UpdateProductAsync(ProductUpdate request);
    Task<ProductDetail> GetProductByIdAsync(int productId);
    Task<bool> DeleteProductAsync(int productId);
    Task<IEnumerable<ProductListItem>> SearchProductByTitle(string productTitle);
}