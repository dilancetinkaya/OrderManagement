using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Jwt;
using OrderManagement.Core.Models;

namespace OrderManagement.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        
        private readonly UserManager<Customer> _userManager;
        private readonly SignInManager<Customer> _signInManager;
        private readonly IConfiguration _configuration;
        public AccountRepository(UserManager<Customer> userManager, SignInManager<Customer> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public string Login(Customer customer, string password)
        {
            _signInManager.PasswordSignInAsync(customer.UserName, password, false, false);
            var token = GenerateJwt.GetJwtToken(customer.UserName, _configuration["Jwt:Key"],
                       _configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], TimeSpan.FromDays(Double.Parse(_configuration["Jwt:ExpirationInDays"]))).ToString();
            return token;
        }

        public void Logout()
        {
            _signInManager.SignOutAsync();
        }

        public async Task Register(Customer customer, string password)
        {
            await _userManager.CreateAsync(
                     new Customer
                     {
                         Email = customer.Email,
                         Name = customer.Name,
                         UserName = customer.UserName


                     }, password);
        }
    }
}
