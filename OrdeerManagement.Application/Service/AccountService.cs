using AutoMapper;
using OrderManagement.Core.Interfaces;
using OrderManagement.Core.Models;
using OrderManagement.Infrastructure.Dto;
using OrderManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public AccountService(IAccountRepository accountRepository,IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }
    public string Login(CustomerDto customerDto, string password)
    {
        var customer = _mapper.Map<Customer>(customerDto);
        var userLogin = _accountRepository.Login(customer, password);
        return userLogin;
    }

    public void Logout()
    {
        _accountRepository.Logout();
    }

    public async Task Register(CreateCustomerDto customerDto)
    {
        var userDto = _mapper.Map<Customer>(customerDto);

        await _accountRepository.Register(userDto, customerDto.Password);
    }
}

