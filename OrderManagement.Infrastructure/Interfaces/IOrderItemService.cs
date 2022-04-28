using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IOrderItemService
{
    Task<List<OrderItemDto>> GetAll();
    Task Add(CreateOrderItemDto orderItemDto );
    void Delete(OrderItemDto orderItemDto);
    void Update(UpdateOrderItemDto orderItemDto, Guid id);
    Task<List<OrderItemDto>> Get(Expression<Func<OrderItemDto, bool>> filter);
   
}

