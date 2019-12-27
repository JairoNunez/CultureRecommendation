using AutoMapper;
using CultureRecommendation.Data.Repositories;
using CultureRecommendation.Infraestructure.Utils;
using CultureRecommendation.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CultureRecommendation.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper(typeof(Startup));

            EntityFrameworkConfig.Configure(services, Configuration);

            services.AddTransient<IHttpClientWrapper, HttpClientWrapper>();
            services.AddTransient<IRecomendationService, RecomendationService>();
            services.AddTransient<IMovieDiscoverFacade, MovieDiscoverFacade>();
            services.AddTransient<IRecommendationRepository, RecommendationRepository>();

            services.AddHttpClient<HttpClientWrapper>();

            SwaggerConfig.Configure(services);
        }
     
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recommendation API v1.0");
            });

            app.UseHttpsRedirection();

            app.UseMvc();
        }

    }

}
