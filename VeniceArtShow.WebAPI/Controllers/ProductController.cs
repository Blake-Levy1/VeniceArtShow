using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (await _productService.CreateProductAsync(request))
            return Ok("Product created successfully.");

        return BadRequest("Product could not be created.");
    }

    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProductById([FromRoute] int productId)
    {
        var detail = await _productService.GetProductByIdAsync(productId);

        return detail is not null
            ? Ok(detail)
            : NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProductById([FromBody] ProductUpdate request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return await _productService.UpdateProductAsync(request)
            ? Ok("Product updated successfully")
            : BadRequest("Product could not be updated");
    }

    [HttpDelete("{productId:int}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
    {
        return await _productService.DeleteProductAsync(productId)
        ? Ok($"Product {productId} was deleted successfully.")
        : BadRequest($"Product {productId} could not be deleted.");
    }
}