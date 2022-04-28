using FluentValidation;
using OrderManagement.Infrastructure.Dto;

namespace OrderManagement.Application.Validations;

public class CustomerOrderValidator : AbstractValidator<CustomerOrderDto>
{
    public CustomerOrderValidator()
    {
        RuleFor(x => x.CustomerId).NotEmpty().WithMessage("customer id cannot null");
        //gelen verinin guid olduğunu kontroler etsin boş guid mi 0000 
      
    }
}
