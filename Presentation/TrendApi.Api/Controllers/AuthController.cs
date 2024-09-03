﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrendApi.Application.Features.Auth.Command.Login;
using TrendApi.Application.Features.Auth.Command.Register;
using TrendApi.Application.Features.Auth.Command.Revoke;
using TrendApi.Application.Features.Auth.Command.RevokeAll;

namespace TrendAPI.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterCommandRequest request)
    {
        await _mediator.Send(request);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginCommandRequest request)
    {
        var response =  await _mediator.Send(request);  
        return StatusCode(StatusCodes.Status200OK, response);
    }

    

    [HttpPost]
    public async Task<IActionResult> Revoke(RevokeCommandRequest request)
    {
        await _mediator.Send(request); 
        return StatusCode(StatusCodes.Status200OK);
    }

    [HttpPost]
    public async Task<IActionResult> RevokeAll()
    {
        await _mediator.Send(new RevokeAllCommandRequest());
        return StatusCode(StatusCodes.Status200OK);
    }

}
