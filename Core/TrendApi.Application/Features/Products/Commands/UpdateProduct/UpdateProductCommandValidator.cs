using FluentValidation;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace TrendApi.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Başlık")
                .NotEqual("string");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithName("Açıklama")
            .NotEqual("string");

        RuleFor(x => x.BrandId)
            .GreaterThan(0)
            .LessThan(4)
            .WithName("Marka");

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0)
            .WithName("Fiyat");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(100)
            .WithName("İndirim Oranı");

        RuleFor(x => x.CategoryIds)
            .NotEmpty()
            .Must(categories => categories.Any())
            .WithName("Kategoriler");
    }
}
