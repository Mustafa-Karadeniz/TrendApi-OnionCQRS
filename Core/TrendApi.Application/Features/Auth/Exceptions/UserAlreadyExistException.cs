using TrendApi.Application.Base;

namespace TrendApi.Application.Features.Auth.Exceptions;

public class UserAlreadyExistException : BaseExceptions
{
    public UserAlreadyExistException() : base("Böyle bir kullanıcı zaten var!") { }
}