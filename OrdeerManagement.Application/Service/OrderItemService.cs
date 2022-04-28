using AutoMapper;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace OrderManagement.Application.Service;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;
    public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;

    }

    public async Task Add(OrderItemDto orderItemDto)
    {
        var orderItem = _mapper.Map<OrderItem>(orderItemDto);
        await _orderItemRepository.Add(orderItem);
    }

    public void Delete(OrderItemDto orderItemDto)
    {
        var deletedorderItem = _mapper.Map<OrderItem>(orderItemDto);
        _orderItemRepository.Delete(deletedorderItem); 
    }

    public async Task<List<OrderItemDto>> Get(Expression<Func<OrderItemDto, bool>> filter)
    {
        var dtoFilter = _mapper.Map<Expression<Func<OrderItem, bool>>>(filter);
        var result = await _orderItemRepository.Get(dtoFilter);
        return _mapper.Map<List<OrderItemDto>>(result);
    }

    public async Task<List<OrderItemDto>> GetAll()
    {
        var orderItems = _orderItemRepository.GetAll();
        var itemsDto = _mapper.Map<List<OrderItemDto>>(orderItems);
        return itemsDto;
    }

    public async Task<int> TotalCount()
    {
        return await _orderItemRepository.TotalCount();
    }

    public void Update(OrderItemDto orderItemDto, Guid id)
    {
        var updatedItem = _mapper.Map<OrderItem>(orderItemDto);
        updatedItem.Id = id;
        _orderItemRepository.Update(updatedItem);
    }
}

