using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderCreate request);
        Task<IEnumerable<OrderListItem>> GetAllOrdersAsync(int buyerId);
        Task<OrderDetail> GetOrderDetailAsync(int orderId);
        Task<IEnumerable<OrderListItem>> GetOrdersByProductIdAsync(int productId);
        Task<IEnumerable<OrderListItem>> GetOrdersByOrderIdAsync(int orderId);
        Task<IEnumerable<OrderListItem>> GetOrdersByArtistIdAsync(GetOrdersByBuyerOrArtistId request);
        Task<bool> DeleteOrderAsync(int OrderId);
        
        // Task<IEnumerable<OrderListItem>> GetOrdersByPurchaseDateAsync(DateTime createdUtc);
        // Task<bool> UpdateOrderAsync(OrderUpdate request);
        // Task<OrderDetail> GetOrderDetailAsync(int orderId);
    }