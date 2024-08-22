using MediatR;

namespace TrendApi.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQueryRequest : IRequest<IList<GetAllProductsQueryResponse>>
{
}
