
using OrderManagement.Core.IRepositories;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories;

public class CustomerOrderRepository : Repository<CustomerOrder>,ICustomerOrderRepository
{
    public CustomerOrderRepository(OrderDbContext context):base(context)
    {

    }
}



