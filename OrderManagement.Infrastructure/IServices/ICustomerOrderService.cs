using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.IServices;

    public interface ICustomerOrderService
    {
    Task<List<CustomerOrderDto>> GetAll();
    
    Task Add(CustomerOrderDto customerOrder);
    void Delete(CustomerOrderDto customerOrder);
    void Update(CustomerOrderDto customerOrder);
    Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
    Task<int> TotalCount();
}

