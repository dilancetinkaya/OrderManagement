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
    Task<List<ProductDto>> GetAll();
    Task Add(ProductDto productDto);
    void Delete(ProductDto productDto);
    void Update(ProductDto productDto);
    Task<List<ProductDto>> Get(Expression<Func<ProductDto, bool>> filter);
    Task<int> TotalCount();





}

