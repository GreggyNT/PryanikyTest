using Core.DTO_s.Product.Request;
using FluentValidation;

namespace Core.Validators;

public class CreateProductRequestValidator:AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(512);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(128);
        RuleFor(x => x.Price).NotEmpty().GreaterThan(0);
        
    }
}