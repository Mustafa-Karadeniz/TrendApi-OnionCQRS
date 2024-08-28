using MediatR;
using Microsoft.AspNetCore.Http;
using TrendApi.Application.Base;
using TrendApi.Application.Features.Products.Rules;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler:BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
 {


    public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        
    }

    public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
    {
        var product = await _unitOfWork.GetReadRepository<Product>().GetAsync(x => x.Id == request.Id && !x.IsDeleted);
        product.IsDeleted = true;

        await _unitOfWork.GetWriteRepository<Product>().UpdateAsync(product);
        await _unitOfWork.SaveAsync();
        return Unit.Value;
    }

}
