using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface ICustomerService
{
    Task<List<CustomerDto>> GetAllAsync();
    Task AddAsync(CreateCustomerDto customerDto);
    Task Delete(string id);
    Task UpdateAsync(UpdateCustomerDto customerDto,string id);
    Task<CustomerDto> GetAsync(string id);
   
}

