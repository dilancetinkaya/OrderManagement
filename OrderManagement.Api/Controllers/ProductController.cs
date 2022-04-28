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

    [HttpGet]
    public IActionResult GetProducts()
    {
        var productList = _productService.GetAll();
        return Ok(productList);

    }

    [HttpGet("{id}")]
    public IActionResult GetProductById(Guid id)
    {
        var product = _productService.Get(x => x.Id == id);
        return Ok(product);

    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(CreateProductDto product)
    {
        await _productService.Add(product);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateProduct(UpdateProductDto product, Guid id)
    {

        _productService.Update(product, id);
        return Ok();


    }
    [HttpDelete("{id}")]
    public IActionResult DeleteProduct(ProductDto product)
    {
        _productService.Delete(product);
        return Ok();
    }
}

