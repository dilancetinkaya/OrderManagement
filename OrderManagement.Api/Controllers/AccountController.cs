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

        [HttpGet("Login")]

        [AllowAnonymous]
        public IActionResult Login(CustomerDto customer, string password)
        {
            var loginUser = _accountService.Login(customer, password);
            if (loginUser == null) return BadRequest();

            return Ok(loginUser);
        }
        [HttpGet("Logout")]
        [AllowAnonymous]
        public IActionResult Logout()
        {
            _accountService.Logout();
            return Ok();
        }
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register(CreateCustomerDto customer)
        {
            await _accountService.Register(customer);
            return Ok();
        }
    }
}
