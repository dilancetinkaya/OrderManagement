using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

