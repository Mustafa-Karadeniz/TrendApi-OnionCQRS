using MediatR;
using Microsoft.AspNetCore.Http;
using TrendApi.Application.Base;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler :BaseHandler, IRequestHandler<UpdateProductCommandRequest , Unit>
{
    public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {

    }
    public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x=>x.Id == request.Id && !x.IsDeleted); //!x.Isdeleted eşittir x..IsDeleted = false anlamına gelir.
        var map =  _mapper.Map<Product, UpdateProductCommandRequest>(request);
        var productCategories1 = await/*son of a ******/ _unitOfWork.GetReadRepository<ProductCategory>().GetAllAsync(x=>x.ProductId == product.Id);
        
        await _unitOfWork.GetWriteRepository<ProductCategory>()
            .HardDeleteRangeAsync((IList<ProductCategory>)productCategories1);

        foreach (var categoryId in request.CategoryIds)
        {
            await _unitOfWork.GetWriteRepository<ProductCategory>()
                .AddAsync(new() { CategoryId = categoryId, ProductId = product.Id });
        }

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(map);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }
}
