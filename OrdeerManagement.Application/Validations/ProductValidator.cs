using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class ProductValidator : AbstractValidator<CreateProductDto>
{
    public ProductValidator()
    {
        RuleFor(x => x.Price).NotEmpty().WithMessage("Price cannot be empty");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty");
        RuleFor(x => x.Barcode).NotEmpty().WithMessage("Barcode cannot be empty");
    }
}

