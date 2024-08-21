using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrendApi.Application.Features.Products.Queries.GetAllProducts;

namespace TrendAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]// action koyduğun seferde IActionResult İsmini alır.
    [ApiController]
    public class ProductCotroller : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCotroller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }
    }
}
