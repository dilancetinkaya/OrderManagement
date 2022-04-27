using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.IServices;

    public interface IProductService
    {
    Task<List<CustomerOrderDto>> GetAll();
    Task Add(CustomerOrderDto productDto);
    void Delete(CustomerOrderDto productDto);
    void Update(CustomerOrderDto productDto);
    Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter);
    Task<int> TotalCount();





}

