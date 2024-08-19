using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrendApi.Persistence.Context;

namespace TrendApi.Persistence;

public static class Registration
{
    //IServiceCollection.AddPersistence şeklinde çalışacak bu sayede proje referansı eklemeden bu methodu presentationda kullanılacak
    //local de çalıştığımdan configuration almam lazım
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
    }
}
