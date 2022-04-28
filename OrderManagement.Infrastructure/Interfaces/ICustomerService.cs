using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAll();
    Task Add(CreateCustomerDto customerDto);
    void Delete(CustomerDto customerDto);
    void Update(UpdateCustomerDto customerDto,string id);
    Task<List<CustomerDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
   
}

