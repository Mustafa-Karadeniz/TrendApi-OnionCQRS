using TrendApi.Application.Base;
using TrendApi.Application.Features.Products.Exceptions;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Products.Rules;

public class ProductRules : BaseRules
{
    public Task ProductTitleMustNotBeSame(IList<Product> products, string requestTitle)
    {
        if (products.Any(x=>x.Title == requestTitle)) throw new ProductTitleMustNotBeSameException();
        return Task.CompletedTask;
    }
}
