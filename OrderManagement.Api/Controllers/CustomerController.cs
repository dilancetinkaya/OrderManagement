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

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var customerList = _customerService.GetAll();
        return Ok(customerList);

    }

    [HttpGet("{id}")]
    public IActionResult GetCustomerById(Guid id)
    {
        var customer = _customerService.Get(x => x.Id == id);
        return Ok(customer);

    }

    [HttpPost]
    public async Task<IActionResult> AddCustomer(CreateCustomerDto customer)
    {
        await _customerService.Add(customer);
        return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateCustomer(UpdateCustomerDto customer, string id)
    {

        _customerService.Update(customer, id);
        return Ok();


    }
    [HttpDelete("{id}")]
    public IActionResult DeleteCustomer(CustomerDto customer)
    {
        _customerService.Delete(customer);
        return Ok();
    }
}

