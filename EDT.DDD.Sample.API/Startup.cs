using AutoMapper;
using EDT.DDD.Sample.API.Application.APIs;
using EDT.DDD.Sample.API.Infrastructure.Context;
using EDT.DDD.Sample.API.Infrastructure.Utils;
using EDT.DDD.Sample.API.Models.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Savorboard.CAP.InMemoryMessageQueue;

namespace EDT.DDD.Sample.API
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
            services.AddControllers();
            services.AddAutofacRegister();
            services.AddWebAPI<IAuthServiceAPI>()
                .AddAutoMapper()
                .AddDbContext<SampleDbContext>(
                    options => options.UseMySql(Configuration["DataBase:ConnStr"]));

            services.AddCap(x =>
            {
                x.UseInMemoryStorage();
                x.UseInMemoryMessageQueue();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EDT.DDD.Sample.API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage()
                    .UseSwagger()
                    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EDT.DDD.Sample.API v1"));
            }

            app.UseHttpsRedirection()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            app.UseAutoMapperMappingProfiles();
        }
    }
}
