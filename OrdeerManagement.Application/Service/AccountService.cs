using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OrderManagement.Application.Service;

public class AccountService : IAccountService
{
    private readonly UserManager<Customer> _userManager;
    private readonly IConfiguration _configuration;

    public AccountService(UserManager<Customer> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;

    }
    public async Task<string> CreateUserAsync(CreateCustomerDto customerDto)
    {
        var user = new Customer { UserName = customerDto.Email, Email = customerDto.Email, Name = customerDto.Name, Address = customerDto.Address };
        var result = await _userManager.CreateAsync(user, customerDto.Password);
        if (!result.Succeeded)
        {
            return string.Empty;
        }

        return user.Id;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _userManager.FindByNameAsync(email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            return string.Empty;
        var signingCredentials = GetSigningCredentials();
        var claims = GetClaims(user);
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return token;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
        var secret = new SymmetricSecurityKey(key);

        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    private List<Claim> GetClaims(IdentityUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim("UserId", user.Id)
            };

        return claims;
    }

    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(5),
            signingCredentials: signingCredentials);

        return tokenOptions;
    }
}

