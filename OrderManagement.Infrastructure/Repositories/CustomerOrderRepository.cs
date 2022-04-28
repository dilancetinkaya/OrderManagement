
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories;

public class CustomerOrderRepository : Repository<CustomerOrder>,ICustomerOrderRepository
{
    public CustomerOrderRepository(OrderDbContext context):base(context)
    {

    }
}



