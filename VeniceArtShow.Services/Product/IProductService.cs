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
    Task<IEnumerable<ProductListItem>> SearchProductByMediaId(int mediaId);
    Task<IEnumerable<ProductListItem>> SearchProductByPrice(double lowPrice, double highPrice);
    Task<IEnumerable<ProductListItem>> SearchProductByArtistId(int artistId);
}