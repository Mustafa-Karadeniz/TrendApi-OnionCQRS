﻿using MediatR;

namespace TrendApi.Application.Features.Products.Commands.DeleteProduct;

public class DeleteProductCommandRequest : IRequest
{
    public int Id { get; set; }
}
