using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using OrderManagement.Infrastructure.Results;

namespace OrderManagement.Application.Service;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly ICustomerOrderRepository _customerOrderRepository;
    private readonly UserManager<Customer> _userManager;
    private readonly IProductRepository _productRepository;

    private readonly IMapper _mapper;
    public CustomerOrderService(ICustomerOrderRepository customerOrderRepository, IMapper mapper, IProductRepository productRepository, UserManager<Customer> userManager)
    {
        _customerOrderRepository = customerOrderRepository;
        _mapper = mapper;

        _productRepository = productRepository;
        _userManager = userManager;
    }

    public async Task<IResult> AddAsync(CreateCustomerOrderDto customerOrderDto)
    {
        CustomerOrder customerOrder = new()
        {
            Address = customerOrderDto.Address,
            Name = customerOrderDto.Name,
            CreatedAt = DateTime.Now,
            Customer = await _userManager.FindByIdAsync(customerOrderDto.CustomerId)
        };
        foreach (var orderItem in customerOrderDto.OrderItems)
        {
            var product = await _productRepository.GetAsync(x => x.Id == orderItem.ProductId);
            if (product is null) return new ErrorResult("Product is not found");
            customerOrder.OrderItems.Add(new OrderItem { Product = product, Quantity = orderItem.Quantity });

        }

        var result = await _customerOrderRepository.AddAsync(customerOrder);
        return result ? new SuccessResult() : new ErrorResult();
    }

    public async Task<IResult> AddOrderItemAsync(Guid customerOrderId, CreateOrderItemDto orderItem)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);

        if (order is null) return new ErrorResult();

        if (order.OrderItems.FirstOrDefault(x => x.ProductId == orderItem.ProductId) != null)
            return new ErrorResult("This product already exists");

        var product = await _productRepository.GetAsync(x => x.Id == orderItem.ProductId);
        if (product is null) return new ErrorResult("Product is not found");

        order.OrderItems.Add(new OrderItem { Product = product, Quantity = orderItem.Quantity });
        var result = _customerOrderRepository.Update(order);
        return result ? new SuccessResult() : new ErrorResult();

    }

    public async Task<IResult> Delete(Guid id)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == id);
        if (order is null) return new ErrorResult();
        var result = _customerOrderRepository.Delete(order);
        return result ? new SuccessResult("Deleted successfully") : new ErrorResult();
    }

    public async Task<IResult> DeletedOrderItemAsync(Guid customerOrderId, Guid productId)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);
        if (order is null) return new ErrorResult();

        var orderItem = order.OrderItems.FirstOrDefault(x => x.Product.Id == productId);
        if (orderItem != null)
        {
            order.OrderItems.Remove(orderItem);
            _customerOrderRepository.Update(order);
            if (!order.OrderItems.Any())
            {
                var result = _customerOrderRepository.Delete(order);
                if (result) return new SuccessResult("Deleted successfully");
            }
        }
        return new ErrorResult();
    }

    public async Task<IDataResult<CustomerOrderDto>> GetAsync(Guid id)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == id);
        if (order is null) return new ErrorDataResult<CustomerOrderDto>();
        var dto = _mapper.Map<CustomerOrderDto>(order);
        return new SuccessDataResult<CustomerOrderDto>(dto);
    }

    public async Task<IDataResult<List<CustomerOrderDto>>> GetAllAsync()
    {
        var orders = await _customerOrderRepository.GetAllAsync();
        if (orders is null || orders.Count == 0) return new ErrorDataResult<List<CustomerOrderDto>>();
        var ordersDto = _mapper.Map<List<CustomerOrderDto>>(orders);
        return new SuccessDataResult<List<CustomerOrderDto>>(ordersDto);
    }

    public async Task<IResult> UpdateCustomerOrderAddressAsync(Guid customerOrderId, string address)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);
        if (order is null) return new ErrorResult();
        order.Address = address;
        var result = _customerOrderRepository.Update(order);
        return result ? new SuccessResult() : new ErrorResult();

    }

    public async Task<IResult> UpdateOrderItemAsync(Guid customerOrderId, UpdateOrderItemDto orderItem)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);
        if (order is null) return new ErrorResult();
        order.OrderItems.FirstOrDefault(x => x.Product.Id == orderItem.ProductId).Quantity = orderItem.Quantity;
        var result = _customerOrderRepository.Update(order);
        return result ? new SuccessResult() : new ErrorResult();
    }
}

