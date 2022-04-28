using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IProductService
    {
    Task<List<ProductDto>> GetAll();
    Task Add(CreateProductDto productDto);
    void Delete(ProductDto productDto);
    void Update(UpdateProductDto productDto,Guid id);
    Task<List<ProductDto>> Get(Expression<Func<ProductDto, bool>> filter);




}

