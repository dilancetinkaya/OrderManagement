using AutoMapper;
using OrderManagement.Core.IRepositories;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

    public async Task Add(CustomerOrderDto customerOrderDto)
    {
        var customerOrder = _mapper.Map<CustomerOrder>(customerOrderDto);
        await _customerOrderRepository.Add(customerOrder);
    }

    public void Delete(CustomerOrderDto customerOrderDto)
    {
        var deletedOrder = _mapper.Map<CustomerOrder>(customerOrderDto);
        _customerOrderRepository.Delete(deletedOrder);
    }

    public Task<List<CustomerOrderDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CustomerOrderDto>> GetAll()
    {
        var orders = _customerOrderRepository.GetAll();
        var ordersDto = _mapper.Map<List<CustomerOrderDto>>(orders);
        return ordersDto;
    }

    public Task<int> TotalCount()
    {
        throw new NotImplementedException();
    }

    public void Update(CustomerOrderDto customerOrderDto)
    {

        var updateOrder = _mapper.Map<CustomerOrder>(customerOrderDto);
        _customerOrderRepository.Update(updateOrder);
        
    }
}

