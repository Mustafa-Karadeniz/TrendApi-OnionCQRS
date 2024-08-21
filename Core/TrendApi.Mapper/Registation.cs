using Microsoft.Extensions.DependencyInjection;
using TrendApi.Application.Interface.AutoMapper;

namespace TrendApi.Mapper;

public static class Registation
{
    public static void AddCustomMapper(this IServiceCollection service)
    {
        service.AddSingleton<IMapper, AutoMapper.Mapper>();
    }
    
}
