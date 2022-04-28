using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAll();
    Task Add(CustomerDto customerDto);
    void Delete(CustomerDto customerDto);
    void Update(CustomerDto customerDto,string id);
    Task<List<CustomerDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
    Task<int> TotalCount();
}

