using MediatR;
using Microsoft.AspNetCore.Http;
using TrendApi.Application.Base;
using TrendApi.Application.Features.Products.Rules;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler :BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
{
    
    private readonly ProductRules _productRules;

    public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
    {
        
        _productRules = productRules;
    }
    public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        IList<Product> products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync();
        
        await _productRules.ProductTitleMustNotBeSame(products, request.Title);


        Product product = new(request.Title, request.Description, request.BrandId, request.Price, request.Discount );
        
        await _unitOfWork.GetWriteRepository<Product>().AddAsync(product);
        if(await _unitOfWork.SaveAsync() > 0)
        {
            foreach (var categoryId in request.CategoryIds)
            {
                await _unitOfWork.GetWriteRepository<ProductCategory>().AddAsync(new()
                {
                    ProductId = product.Id,
                    CategoryId = categoryId,
                });
            }

            await _unitOfWork.SaveAsync();
        }
        return Unit.Value;
    }
}
