using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class OrderItemValidator : AbstractValidator<CreateOrderItemDto>
{
    public OrderItemValidator()
    {
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId cannot be empty");
        RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity cannot be empty");
       
    }
}

