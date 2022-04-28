using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class CustomerValidator : AbstractValidator<CustomerDto>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("name  cannot null");
    }
}

