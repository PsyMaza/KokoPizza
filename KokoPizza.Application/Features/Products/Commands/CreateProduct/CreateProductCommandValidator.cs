using FluentValidation;

namespace KokoPizza.Core.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50)
            .WithMessage("{PropertyName} must not exceed 50 characters.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(0)
            .WithMessage("{PropertyName} must greater than 0.");

        RuleFor(p => p.CategoryId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull();
    }
}