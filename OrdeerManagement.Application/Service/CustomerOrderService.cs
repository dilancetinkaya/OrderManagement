using AutoMapper;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace OrderManagement.Application.Service;

public class CustomerOrderService : ICustomerOrderService
{
    private readonly ICustomerOrderRepository _customerOrderRepository;
    private readonly IMapper _mapper;
    public CustomerOrderService(ICustomerOrderRepository customerOrderRepository, IMapper mapper)
    {
        _customerOrderRepository = customerOrderRepository;
        _mapper = mapper;
    }

    public async Task Add(CreateCustomerOrderDto customerOrderDto)
    {
        var customerOrder = _mapper.Map<CustomerOrder>(customerOrderDto);
        await _customerOrderRepository.Add(customerOrder);
    }

    public async Task AddOrderItem(Guid customerOrderId, CreateOrderItemDto orderItem)
    {
       await _customerOrderRepository.GetManyAsync(x => x.Id == customerOrderId);
    }

    public void Delete(CustomerOrderDto customerOrderDto)
    {
        var deletedOrder = _mapper.Map<CustomerOrder>(customerOrderDto);
        _customerOrderRepository.Delete(deletedOrder);
    }

    public async Task DeletedOrderItem(Guid customerOrderId, Guid productId)
    {
        var order=await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);
        order.OrderItems.FirstOrDefault(x => x.Product.Id == productId);
        _customerOrderRepository.Delete(order);
    }

    public async Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter)
    {
        var dtoFilter = _mapper.Map<Expression<Func<CustomerOrder, bool>>>(filter);
        var result = await _customerOrderRepository.GetManyAsync(dtoFilter);
        return _mapper.Map<List<CustomerOrderDto>>(result);
    }

    public async Task<List<CustomerOrderDto>> GetAll()
    {
        var orders = _customerOrderRepository.GetAll();
        var ordersDto = _mapper.Map<List<CustomerOrderDto>>(orders);
        return ordersDto;
    }

    public async Task UpdateCustomerOrderAddredd(Guid customerOrderId, string address)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);
        order.Address = address;
        _customerOrderRepository.Update(order);
    }

    public async Task UpdateOrderItem(Guid customerOrderId, UpdateOrderItemDto orderItem)
    {
        var order = await _customerOrderRepository.GetAsync(x => x.Id == customerOrderId);
        order.OrderItems.FirstOrDefault(x => x.Product.Id == orderItem.ProductId).Quantity = orderItem.Quantity;
        _customerOrderRepository.Update(order);

    }
}

