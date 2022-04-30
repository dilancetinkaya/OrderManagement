using Microsoft.AspNetCore.Mvc;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerOrderController : ControllerBase
{
    private readonly ICustomerOrderService _customerOrderService;
    public CustomerOrderController(ICustomerOrderService customerOrderService)
    {
        _customerOrderService = customerOrderService;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetOrders()
    {
        var result = await _customerOrderService.GetAllAsync();
        return result.Success ? Ok(result) : NotFound(result);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderById(Guid id)
    {
        var result = await _customerOrderService.GetAsync(id);
        return result.Success ? Ok(result) : NotFound(result);

    }

    [HttpPost]
    public async Task<IActionResult> AddOrder(CreateCustomerOrderDto order)
    {
        var result = await _customerOrderService.AddAsync(order);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("OrderItem/{id}")]
    public async Task<IActionResult> AddOrderItem(Guid id, CreateOrderItemDto orderItem)
    {
        var result = await _customerOrderService.AddOrderItemAsync(id, orderItem);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    [HttpPut("OrderItem/{id}")]
    public async Task<IActionResult> UpdateOrderItem(Guid id, UpdateOrderItemDto orderItem)
    {
        var result = await _customerOrderService.UpdateOrderItemAsync(id, orderItem);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    [HttpPut("Address/{id}")]
    public async Task<IActionResult> UpdateCustomerOrderAddress(Guid id, string address)
    {
        var result = await _customerOrderService.UpdateCustomerOrderAddressAsync(id, address);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    [HttpDelete("OrderItem/{id}")]
    public async Task<IActionResult> DeleteOrderItem(Guid id, Guid productId)
    {
        var result = await _customerOrderService.DeletedOrderItemAsync(id, productId);
        return result.Success ? Ok(result) : BadRequest(result);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(Guid id)
    {
        var result = await _customerOrderService.Delete(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}