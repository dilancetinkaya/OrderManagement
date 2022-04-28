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

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orderList = _customerOrderService.GetAll();
        return Ok(orderList);

    }

    [HttpGet("{id}")]
    public IActionResult GetOrderById(Guid id)
    {
        var order = _customerOrderService.Get(x => x.Id == id);
        return Ok(order);

    }

    [HttpPost]
    public async Task<IActionResult> AddOrder(CreateCustomerOrderDto order)
    {
        await _customerOrderService.Add(order);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateOrder(UpdateCustomerOrderDto order, Guid id)
    {

        _customerOrderService.Update(order, id);
        return Ok();


    }
    [HttpDelete("{id}")]
    public IActionResult DeleteOrder(CustomerOrderDto order)
    {
        _customerOrderService.Delete(order);
        return Ok();
    }
}


