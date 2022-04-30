using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Results;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerOrderService
    {
    Task<IDataResult<List<CustomerOrderDto>>> GetAllAsync();
    Task<IResult> AddAsync(CreateCustomerOrderDto customerOrderDto);
    Task<IResult> Delete(Guid id);
    Task<IResult> UpdateOrderItemAsync(Guid customerOrderId, UpdateOrderItemDto orderItem);
    Task<IResult> UpdateCustomerOrderAddressAsync(Guid customerOrderId, string address);
    Task<IResult> DeletedOrderItemAsync(Guid customerOrderId, Guid productId);
    Task<IResult> AddOrderItemAsync(Guid customerOrderId,CreateOrderItemDto orderItem);
    Task<IDataResult<CustomerOrderDto>> GetAsync(Guid id);
   
}

