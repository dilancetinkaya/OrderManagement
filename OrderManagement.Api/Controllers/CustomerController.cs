using Microsoft.AspNetCore.Mvc;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{

    private readonly ICustomerService _customerService;
    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("List")]
    public async Task<IActionResult> GetCustomers()
    {
        var customerList = await _customerService.GetAllAsync();
        return Ok(customerList);

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(string id)
    {
        var customer = await _customerService.GetAsync(id);
        return Ok(customer);

    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(CreateCustomerDto customer)
    {
        await _customerService.AddAsync(customer);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto customer, string id)
    {
        await _customerService.UpdateAsync(customer, id);
        return Ok();


    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        await _customerService.Delete(id);
        return Ok();
    }
}

