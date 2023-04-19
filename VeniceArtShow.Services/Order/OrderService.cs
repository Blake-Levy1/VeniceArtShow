using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class OrderService : IOrderService
    {
        private readonly int _userId;
        public OrderService(IHttpContextAccessor httpContextAccessor)
        {

            var userClaims = httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);
            if (!validId)
                throw new Exception("Attempted to create an Order without a valid User."
                );
        }
    }