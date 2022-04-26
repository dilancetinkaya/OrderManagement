using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Core.IRepositories;

public interface ICustomerOrderRepository
{
    public List<CustomerOrder> GetCustomertOrder();
    public CustomerOrder GetCustomerOrderById(Guid id);
    public void CreateCustomerOrder(CustomerOrder customerOrder);
    public void UpdateCustomerOrder(CustomerOrder customerOrder);
    public void DeleteCustomerOrder(Guid id);
}

