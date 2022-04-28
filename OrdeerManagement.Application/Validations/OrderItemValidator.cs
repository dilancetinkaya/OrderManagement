using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class OrderItemValidator : AbstractValidator<OrderItemDto>
{
    public OrderItemValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("order id cannot null");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("product id cannot null");
    }
}

