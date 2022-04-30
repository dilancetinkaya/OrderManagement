using AutoMapper;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;

namespace OrderManagement.Application.Service;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IProductRepository productRepository,IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task AddAsync(CreateProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.AddAsync(product);
    }

    public async Task Delete(Guid id)
    {
        var product = await _productRepository.GetAsync(x=>x.Id == id);
          _productRepository.Delete(product);
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var result = await _productRepository.GetAsync(x=>x.Id==id);
        return _mapper.Map<ProductDto>(result);
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products =await _productRepository.GetAllAsync();
        var productsDto = _mapper.Map<List<ProductDto>>(products);
        return productsDto;
    }



    public void Update(UpdateProductDto productDto,Guid id)
    {
        var updatedProduct = _mapper.Map<Product>(productDto);
        updatedProduct.Id = id;
        _productRepository.Update(updatedProduct);
    }
}

