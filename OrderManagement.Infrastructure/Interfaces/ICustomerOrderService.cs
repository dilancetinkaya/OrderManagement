using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerOrderService
    {
    Task<List<CustomerOrderDto>> GetAll();
    
    Task Add(CustomerOrderDto customerOrderDto);
    void Delete(CustomerOrderDto customerOrderDto);
    void Update(CustomerOrderDto customerOrderDto, Guid id);
    Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
    Task<int> TotalCount();
}

