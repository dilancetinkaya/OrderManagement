using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IProductService
    {
    Task<List<ProductDto>> GetAll();
    Task Add(ProductDto productDto);
    void Delete(ProductDto productDto);
    void Update(ProductDto productDto,Guid id);
    Task<List<ProductDto>> Get(Expression<Func<ProductDto, bool>> filter);
    Task<int> TotalCount();





}

