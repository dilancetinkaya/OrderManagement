using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IOrderItemService
{
    Task<List<OrderItemDto>> GetAll();
    Task Add(OrderItemDto orderItemDto );
    void Delete(OrderItemDto orderItemDto);
    void Update(OrderItemDto orderItemDto, Guid id);
    Task<List<OrderItemDto>> Get(Expression<Func<OrderItemDto, bool>> filter);
    Task<int> TotalCount();
}

