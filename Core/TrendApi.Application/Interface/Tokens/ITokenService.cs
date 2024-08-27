using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Interface.Tokens;

public interface ITokenService
{
    Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);

    string GenerateRefreshToken();

    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
}
