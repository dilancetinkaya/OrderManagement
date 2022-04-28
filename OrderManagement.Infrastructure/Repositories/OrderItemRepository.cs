using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Context;

namespace OrderManagement.Infrastructure.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(OrderDbContext context) : base(context)
    {

    }
}

