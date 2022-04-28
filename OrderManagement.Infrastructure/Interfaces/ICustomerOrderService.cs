using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerOrderService
    {
    Task<List<CustomerOrderDto>> GetAll();
    
    Task Add(CreateCustomerOrderDto customerOrderDto);
    void Delete(CustomerOrderDto customerOrderDto);
    void Update(UpdateCustomerOrderDto customerOrderDto, Guid id);
    Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
   
}

