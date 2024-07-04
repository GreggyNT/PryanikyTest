using Core.DTO.Order.Requests;
using FluentValidation;

namespace Core.Validators;

public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestValidator()
    {
        RuleFor(order => order.OrderSum)
            .NotEmpty();
        RuleFor(order => order.OrderDate)
            .NotEmpty();
        RuleFor(order => order.Status)
            .NotNull();
    }
}