using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using System.Linq.Expressions;

namespace OrderManagement.Application.Service;

public class CustomerService : ICustomerService
{

   
    private readonly UserManager<Customer> _userManager;
    private readonly IMapper _mapper;
    public CustomerService( IMapper mapper, UserManager<Customer> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    public async Task AddAsync(CreateCustomerDto customerDto)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        await _userManager.CreateAsync(customer);
        await _userManager.CreateAsync(customer);
    }

    public async Task Delete(string id)
    {
        var customer = await _userManager.FindByIdAsync(id);
        await _userManager.DeleteAsync(customer);
    }

    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var customers = _userManager.Users;
        var customersDto = _mapper.Map<List<CustomerDto>>(customers);
        return customersDto;
    }



    public async Task UpdateAsync(UpdateCustomerDto customerDto, string id)
    {
        var customer = await _userManager.FindByIdAsync(id);
        customer.Name = customerDto.Name;
        customer.Address = customerDto.Address;
        await _userManager.UpdateAsync(customer);
    }

    public async Task<CustomerDto> GetAsync(string id)
    {
        var customer = await _userManager.FindByIdAsync(id);
        return _mapper.Map<CustomerDto>(customer);

    }
}

