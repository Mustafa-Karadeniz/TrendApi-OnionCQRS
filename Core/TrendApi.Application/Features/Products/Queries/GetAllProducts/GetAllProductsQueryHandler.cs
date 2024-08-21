using MediatR;
using Microsoft.EntityFrameworkCore;
using TrendApi.Application.DTOs;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Product>().GetAllAsync(include: x => x.Include(b => b.Brand));
            var brand = _mapper.Map<BrandDto, Brand>(new Brand());
           

            //foreach (var product in products) 
            //{
            //    response.Add(new GetAllProductsQueryResponse
            //    {
            //        Title = product.Title,
            //        Description = product.Description,
            //        Discount = product.Discount,
            //        Price = product.Price - (product.Price* product.Discount / 100),//İndirimli Fiyatı verdik.
            //    }); 
            //}

            var map = _mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
            {
                item.Price -= (item.Price * item.Discount / 100);
            }

            return map;
        }
    }
}
