using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService  accountService)
        {
            _accountService = accountService;
        }


        [HttpPost("create")]
        public async Task<ActionResult<string>> Post([FromBody] CreateCustomerDto customer)
        {
            return await _accountService.CreateUserAsync(customer);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody] LoginUserDto customer)
        {
            return await _accountService.LoginAsync(customer.Email, customer.Password);
        }



    }
}
