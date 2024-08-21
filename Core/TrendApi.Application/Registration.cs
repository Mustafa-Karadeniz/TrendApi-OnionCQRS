using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TrendApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly   = Assembly.GetExecutingAssembly();

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

    }
}
