using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrderCreate request);
        Task<IEnumerable<OrderListWork>> GetAllOrdersAsync();
        Task<OrderDetail> GetOrderByIdAsync(int orderId);
    }