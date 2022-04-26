using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.IRepositories;

public interface ICustomerRepository
{
    public List<Customer> GetCustomert();
    public Customer GetCustomerById(Guid id);
    public void CreateCustomer(Customer customer);
    public void UpdateCustomer(Customer customer);
    public void DeleteCustomer(Guid id);
}

