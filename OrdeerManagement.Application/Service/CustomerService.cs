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

    public Task<List<CustomerDto>> Get(Expression<Func<CustomerOrderDto, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public async Task<List<CustomerDto>> GetAll()
    {
        var customers = _customerRepository.GetAll();
        var customersDto = _mapper.Map<List<CustomerDto>>(customers);
        return customersDto;
    }

    public Task<int> TotalCount()
    {
        throw new NotImplementedException();
    }

    public void Update(CustomerDto customerDto)
    {
        var updatedCustomer = _mapper.Map<Customer>(customerDto);
        _customerRepository.Update(updatedCustomer);
    }
}

