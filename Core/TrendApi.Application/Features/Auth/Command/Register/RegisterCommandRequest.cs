﻿using MediatR;

namespace TrendApi.Application.Features.Auth.Command.Register;

public class RegisterCommandRequest : IRequest<Unit>
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }
}