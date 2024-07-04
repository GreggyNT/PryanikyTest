using Core.DTO.OrderItem.Requests;
using FluentValidation;

namespace Core.Validators;

public class OrderItemDtoValidator : AbstractValidator<OrderItemDTO>
{
    public OrderItemDtoValidator()
    {
        RuleFor(orderItem => orderItem.OrderId)
            .NotNull();
        RuleFor(orderItem => orderItem.ProductId)
            .NotNull();
        RuleFor(orderItem => orderItem.Quantity)
            .NotEmpty();
    }
}