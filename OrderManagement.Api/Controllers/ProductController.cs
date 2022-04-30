using Microsoft.AspNetCore.Mvc;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetProducts()
    {
        var productList = await _productService.GetAllAsync();
        return Ok(productList);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _productService.GetAsync(id);
        return Ok(product);

    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductDto product)
    {
        await _productService.AddAsync(product);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(UpdateProductDto product, Guid id)
    {

        _productService.Update(product, id);
        return Ok();


    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
       await _productService.Delete(id);
       return Ok();
    }
}

