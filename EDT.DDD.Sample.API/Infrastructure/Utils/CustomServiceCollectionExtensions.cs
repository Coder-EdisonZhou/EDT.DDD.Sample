using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApiClient;

namespace EDT.DDD.Sample.API.Infrastructure.Utils
{
    public static class CustomServiceCollectionExtensions
    {
        public static IServiceCollection AddWebAPI<T>(this IServiceCollection services, string apiHost = null)
            where T : class, IHttpApi
        {
            services.AddHttpClient<T>().AddTypedClient((client, p) =>
            {
                var httpApiConfig = new HttpApiConfig(client)
                {
                    HttpClient = { Timeout = TimeSpan.FromMinutes(1) },
                    HttpHost = new Uri(apiHost ?? p.GetService<IConfiguration>()["Host:ApiGateway"])
                };

                return HttpApiClient.Create<T>(httpApiConfig);
            });

            return services;
        }

        public static AutofacServiceProvider AddAutofacRegister(this IServiceCollection services)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);
            containerBuilder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("Repository")).UsingConstructor().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("DomainService")).UsingConstructor().AsSelf().InstancePerLifetimeScope();
            containerBuilder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("Factory")).UsingConstructor().AsSelf().SingleInstance();
            containerBuilder.RegisterAssemblyTypes(typeof(Startup).Assembly).AsImplementedInterfaces().Where(t => t.Name.EndsWith("ApplicationService")).UsingConstructor().AsSelf().InstancePerLifetimeScope();
            var autofacContainer = new AutofacServiceProvider(containerBuilder.Build());

            return autofacContainer;
        }
    }
}
