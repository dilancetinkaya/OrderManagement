using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IAccountService
{
    public string Login(CustomerDto customerDto, string password);
    public void Logout();
    public Task Register(CreateCustomerDto customerDto);
}

