using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerOrderService
    {
    Task<List<CustomerOrderDto>> GetAll();
    
    Task Add(CreateCustomerOrderDto customerOrderDto);
    void Delete(CustomerOrderDto customerOrderDto);
    Task UpdateOrderItem(Guid customerOrderId, UpdateOrderItemDto orderItem);
    Task UpdateCustomerOrderAddredd(Guid customerOrderId, string address);
    Task DeletedOrderItem(Guid customerOrderId, Guid productId);
    Task AddOrderItem(Guid customerOrderId,CreateOrderItemDto orderItem);
    Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
   
}

