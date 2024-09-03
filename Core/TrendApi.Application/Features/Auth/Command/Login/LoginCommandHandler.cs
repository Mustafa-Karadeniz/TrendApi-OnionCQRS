using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using TrendApi.Application.Base;
using TrendApi.Application.Features.Auth.Rules;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Application.Interface.Tokens;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Auth.Command.Login;

public class LoginCommandHandler : BaseHandler , IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ITokenService _tokenService;
    private readonly AuthRules _authRules;

    public LoginCommandHandler(UserManager<User> userManager, IConfiguration configuration, ITokenService tokenService, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _userManager = userManager;
        _configuration = configuration;
        _tokenService = tokenService;
        _authRules = authRules;
    }
    
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        bool checkPassword = await _userManager.CheckPasswordAsync(user, request.Password);
        await _authRules.EmailOrPasswordShouldNotBeInvalid(user, checkPassword);

        IList<string> roles = await _userManager.GetRolesAsync(user);

        JwtSecurityToken token = await _tokenService.CreateToken(user, roles);
        string refreshToken = _tokenService.GenerateRefreshToken();

        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        await _userManager.UpdateAsync(user);
        await _userManager.UpdateSecurityStampAsync(user);

        string _token = new JwtSecurityTokenHandler().WriteToken(token);

        await _userManager.SetAuthenticationTokenAsync(user, "Default", "AccessToken", _token);

        return new()
        {
            Token = _token,
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        };

    }
}
