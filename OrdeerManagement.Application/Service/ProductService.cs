using AutoMapper;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
    public async Task Add(ProductDto productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _productRepository.Add(product);
    }

    public void Delete(ProductDto productDto)
    {
        var deletedProduct = _mapper.Map<Product>(productDto);
         _productRepository.Delete(deletedProduct);
    }

    public async Task<List<ProductDto>> Get(Expression<Func<ProductDto, bool>> filter)
    {
        var dtoFilter = _mapper.Map<Expression<Func<Product, bool>>>(filter);
        var result = await _productRepository.Get(dtoFilter);
        return _mapper.Map<List<ProductDto>>(result);
    }

    public async Task<List<ProductDto>> GetAll()
    {
        var products = _productRepository.GetAll();
        var productsDto = _mapper.Map<List<ProductDto>>(products);
        return productsDto;
    }

    public async Task<int> TotalCount()
    {
        return await _productRepository.TotalCount();
    }

    public void Update(ProductDto productDto,Guid id)
    {
        var updatedProduct = _mapper.Map<Product>(productDto);
        updatedProduct.Id = id;
        _productRepository.Update(updatedProduct);
    }
}

