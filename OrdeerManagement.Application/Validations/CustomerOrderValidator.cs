using FluentValidation;
using OrderManagement.Infrastructure.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Validations;

public class CustomerOrderValidator : AbstractValidator<CustomerOrderDto>
{
    public CustomerOrderValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("customer id cannot null");
      
    }
}
