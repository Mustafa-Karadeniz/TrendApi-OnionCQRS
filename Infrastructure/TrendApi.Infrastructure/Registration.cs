using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendApi.Application.Interface.Tokens;
using TrendApi.Infrastructure.Tokens;

namespace YoutubeApi.Infrastructure
{
    public static class Registration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("JWT"));
            services.AddTransient<ITokenService, TokenService>();
        }
    }
}
