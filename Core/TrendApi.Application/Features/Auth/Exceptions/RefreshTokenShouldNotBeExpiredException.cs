using TrendApi.Application.Base;

namespace TrendApi.Application.Features.Auth.Exceptions;

public class RefreshTokenShouldNotBeExpiredException : BaseExceptions
{
    public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sona ermiştir. Lütfen tekrar giriş yapın.") { }
}