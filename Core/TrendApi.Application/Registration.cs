using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;
using TrendApi.Application.Exceptions;
using TrendApi.Application.Behaviours;
using TrendApi.Application.Features.Products.Rules;
using TrendApi.Application.Base;

namespace YoutubeApi.Application;

public static class Registration
{
    public static void AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddTransient<ExceptionMiddleware>();

        services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));

        services.AddValidatorsFromAssembly(assembly);
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
    }

   private static IServiceCollection AddRulesFromAssemblyContaining(
       this IServiceCollection services,
       Assembly assembly,
       Type type)
    {
        var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types) 
            services.AddTransient(item);

        return services;
    }
}

