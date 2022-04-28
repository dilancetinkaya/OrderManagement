using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IAccountService
{
    Task<string> LoginAsync(string email, string password);

    Task<string> CreateUserAsync(CreateCustomerDto customerDto);
}

