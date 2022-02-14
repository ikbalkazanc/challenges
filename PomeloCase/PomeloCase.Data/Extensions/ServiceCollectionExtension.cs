using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PomeloCase.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPomeloData(this IServiceCollection services,string connectionString)
        {

            services.AddScoped(typeof(DataRepository));
            services.AddDbContext<DatabaseContext>(options =>
            {
                
                options.UseNpgsql(connectionString);
            });
            return services;
        }
    }
}