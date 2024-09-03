using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TrendApi.Application.Base;
using TrendApi.Application.Features.Auth.Rules;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Domain.Entites;

namespace TrendApi.Application.Features.Auth.Command.Revoke;

public class RevokeCommandHandler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> _userManager;
    private readonly AuthRules _authRules;

    public RevokeCommandHandler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        _userManager = userManager;
        _authRules = authRules;//mail  adresi bulunuyor mu?  Diye bakmak için
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User user = await _userManager.FindByEmailAsync(request.Email);
        await _authRules.EmailAddressShouldBeValid(user);

        user.RefreshToken = null;
        
        await _userManager.UpdateAsync(user);

        return Unit.Value;
    }
}