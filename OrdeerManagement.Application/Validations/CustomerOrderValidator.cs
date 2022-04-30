using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class CustomerOrderValidator : AbstractValidator<CreateCustomerOrderDto>
{
    public CustomerOrderValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("customerid cannot null");
         
    }
}
