using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrendApi.Application.Interface.AutoMapper;
using TrendApi.Application.Interface.IUnitOfWorks;

namespace TrendApi.Application.Base;

public class BaseHandler
{
    public readonly IMapper _mapper;
    public readonly IUnitOfWork _unitOfWork;
    public readonly IHttpContextAccessor _httpContextAccessor;
    public readonly string userId;
    public BaseHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _httpContextAccessor = httpContextAccessor;
        userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
