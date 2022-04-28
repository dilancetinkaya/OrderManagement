using OrderManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.Interfaces;

public interface IAccountRepository
{
    public string Login(Customer customer, string password);
    public void Logout();
    public Task Register(Customer customer, string password);
}

