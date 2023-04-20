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

    [HttpGet("AllProducts")]
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

    [HttpGet("{productTitle:string}")]
    public async Task<IActionResult> SearchProductByTitle([FromRoute] string productTitle)
    {
        var products = await _productService.SearchProductByTitle(productTitle);
        return Ok(products);
    }

    [HttpGet("productMediaId:int")]
    public async Task<IActionResult> SearchProductByMediaId([FromRoute] int mediaId)
    {
        var products = await _productService.SearchProductByMediaId(mediaId);
        return Ok(products);
    }

    [HttpGet("{productPrice:double}")]
    public async Task<IActionResult> SearchProductByPrice([FromRoute] double price)
    {
        var products = await _productService.SearchProductByPrice(price);
        return Ok(products);
    }

    [HttpGet("{product:ArtistId:string}")]
    public async Task<IActionResult> SearchProductByArtistId([FromRoute] string artistId)
    {
        var products = await _productService.SearchProductByArtistId(artistId);
        return Ok(products);
    }
}