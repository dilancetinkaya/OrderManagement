using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IAccountService
{
    public string Login(CustomerDto customerDto, string password);
    public void Logout();
    public Task Register(CreateCustomerDto customerDto);
}

