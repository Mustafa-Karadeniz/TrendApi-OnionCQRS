using FluentValidation;
namespace TrendApi.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommandRequest>
{
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .GreaterThan(0)
            .WithName("Silinecek Ürün Id");

    }
}
