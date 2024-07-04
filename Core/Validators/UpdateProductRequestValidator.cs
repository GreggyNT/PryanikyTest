using Core.DTO_s.Product.Request;
using FluentValidation;

namespace Core.Validators;

public class UpdateProductRequestValidator:AbstractValidator<UpdateProductRequest>
{
    public UpdateProductRequestValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
    }
}