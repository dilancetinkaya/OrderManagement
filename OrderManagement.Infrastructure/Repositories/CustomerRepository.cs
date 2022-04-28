using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories;

public class CustomerRepository :Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(OrderDbContext context):base(context)
    {

    }   
}

