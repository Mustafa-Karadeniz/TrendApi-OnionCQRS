using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrendApi.Application.Features.Products.Commands.CreateProduct;
using TrendApi.Application.Features.Products.Commands.UpdateProduct;
using TrendApi.Application.Features.Products.Commands.DeleteProduct;
using TrendApi.Application.Features.Products.Queries.GetAllProducts;
using Microsoft.AspNetCore.Authorization;

namespace TrendAPI.Api.Controllers
{
    [Route("api/[controller]/[action]")]// action koyduğun seferde IActionResult İsmini alır.
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommandRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

    }
}
