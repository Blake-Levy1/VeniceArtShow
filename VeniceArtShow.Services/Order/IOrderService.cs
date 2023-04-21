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
        Task<bool> UpdateOrderAsync(OrderUpdate request);
        // Task<OrderDetail> GetOrderByIdAsync(int orderId);
        Task<bool> DeleteOrderAsync(int OrderId);
        
    }