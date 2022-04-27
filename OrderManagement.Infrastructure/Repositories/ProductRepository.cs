using OrderManagement.Core.IRepositories;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories;

public class ProductRepository :Repository<Product>, IProductRepository
{
    public ProductRepository(OrderDbContext context):base(context)
    {

    }
}

