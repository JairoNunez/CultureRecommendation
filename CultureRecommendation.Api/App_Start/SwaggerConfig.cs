using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CultureRecommendation.Api
{
    public class SwaggerConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Recommendation  API", Version = "v1" });
            });
        }
    }
}
