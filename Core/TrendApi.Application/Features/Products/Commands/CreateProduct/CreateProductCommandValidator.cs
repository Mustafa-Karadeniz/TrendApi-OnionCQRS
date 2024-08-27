using FluentValidation;
using TrendApi.Application.Features.Products.Commands.CreateProduct;

namespace YoutubeApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
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
                .WithName("İndirim Oranı");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Kategoriler");

        }
    }
}