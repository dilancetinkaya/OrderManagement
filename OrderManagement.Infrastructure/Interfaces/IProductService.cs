using OrderManagement.Infrastructure.Dto;
using System.Linq.Expressions;

namespace OrderManagement.Infrastructure.Interfaces;

public interface IProductService
    {
    Task<List<ProductDto>> GetAllAsync();
    Task AddAsync(CreateProductDto productDto);
    Task Delete(Guid id);
    void Update(UpdateProductDto productDto,Guid id);
    Task<ProductDto> GetAsync(Guid id);




}

