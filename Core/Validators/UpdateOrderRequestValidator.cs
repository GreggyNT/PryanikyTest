using Core.DTO.Order.Requests;
using FluentValidation;

namespace Core.Validators;

public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
{
    public UpdateOrderRequestValidator()
    {
        RuleFor(order => order.Id)
            .NotEmpty();
        RuleFor(order => order.Status)
            .NotNull();
        RuleFor(order => order.OrderSum)
            .NotEmpty();
    }
}