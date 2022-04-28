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

public class CustomerService : ICustomerService
{

    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task Add(CustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _customerRepository.Add(customer);
    }

    public void Delete(CustomerDto customerDto)
    {
        var deletedCustomer = _mapper.Map<Customer>(customerDto);
        _customerRepository.Delete(deletedCustomer);
    }

  

    public async Task<List<CustomerDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter)
    {
        var dtoFilter = _mapper.Map<Expression<Func<Customer, bool>>>(filter);
        var result = await _customerRepository.Get(dtoFilter);
        return _mapper.Map<List<CustomerDto>>(result);
    }

    public async Task<List<CustomerDto>> GetAll()
    {
        var customers = _customerRepository.GetAll();
        var customersDto = _mapper.Map<List<CustomerDto>>(customers);
        return customersDto;
    }

    public async Task<int> TotalCount()
    {
        return await _customerRepository.TotalCount();
    }

    public void Update(CustomerDto customerDto, string id)
    {
        var updatedCustomer = _mapper.Map<Customer>(customerDto);
        updatedCustomer.Id = id;
        _customerRepository.Update(updatedCustomer);
    }
}

