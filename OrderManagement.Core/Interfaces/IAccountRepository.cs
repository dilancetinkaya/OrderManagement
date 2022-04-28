using OrderManagement.Core.Models;

namespace OrderManagement.Core.Interfaces;

public interface IAccountRepository
{
    public string Login(Customer customer, string password);
    public void Logout();
    public Task Register(Customer customer, string password);
}

