using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class ProductService : IProductService
{
    public ProductService(IHttpContextAccessor httpContextAccessor)
    {
        
    }
}