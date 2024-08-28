using MediatR;
using System.ComponentModel;


namespace TrendApi.Application.Features.Auth.Command.Login
{
    public class LoginCommandRequest : IRequest<LoginCommandResponse>
    {
        [DefaultValue("mustafa@gmail.com")]
        public string Email { get; set; }
        [DefaultValue("asd123")]
        public string Password { get; set; }
    }
}