using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendApi.Application.Interface.IUnitOfWorks;
using TrendApi.Application.Interface.Repositories;
using TrendApi.Domain.Entites;
using TrendApi.Persistence.Context;
using TrendApi.Persistence.UnitOfWorks;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Persistence.Repositories;

namespace TrendApi.Persistence;

public static class Registration
{
    //IServiceCollection.AddPersistence şeklinde çalışacak bu sayede proje referansı eklemeden bu methodu presentationda kullanılacak
    //local de çalıştığımdan configuration almam lazım
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => 
        opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddIdentityCore<User>(opt =>
        {
            opt.Password.RequireNonAlphanumeric = false;
            opt.Password.RequiredLength = 2;
            opt.Password.RequireLowercase = false;
            opt.Password.RequireUppercase = false;
            opt.Password.RequireDigit = false;
            opt.SignIn.RequireConfirmedEmail = false;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
}
