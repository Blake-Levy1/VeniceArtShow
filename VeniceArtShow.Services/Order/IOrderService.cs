using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderCreate request);
        Task<IEnumerable<OrderListItem>> GetAllOrdersAsync();
        Task<OrderDetail> GetOrderDetailAsync(int orderId);
        Task<IEnumerable<OrderListItem>> GetOrdersByProductIdAsync(int productId);
        Task<IEnumerable<OrderListItem>> GetOrdersByPurchaseDateAsync(DateTime createdUtc);
        Task<IEnumerable<OrderListItem>> GetOrdersByArtistIdAsync(string artistId);
        
        Task<bool> UpdateOrderAsync(OrderUpdate request);
        Task<bool> DeleteOrderAsync(int OrderId);
        
    }