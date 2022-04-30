using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class CustomerValidator : AbstractValidator<CreateCustomerDto>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Address cannot be empty");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email cannot be empty");
    }
}

