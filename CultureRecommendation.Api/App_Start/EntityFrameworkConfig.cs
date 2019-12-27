using CultureRecommendation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CultureRecommendation.Api
{
    public class EntityFrameworkConfig
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextCulture>
                (o => o.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IDbContextCulture, DbContextCulture>();
        }


    }
}
