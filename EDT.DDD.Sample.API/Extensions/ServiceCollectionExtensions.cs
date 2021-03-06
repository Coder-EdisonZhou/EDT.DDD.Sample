using EDT.DDD.Sample.API.Application.APIs;
using EDT.DDD.Sample.API.Infrastructure.Utils;
using Microsoft.Extensions.DependencyInjection;

namespace EDT.DDD.Sample.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReferencedWebAPIs(this IServiceCollection services)
        {
            services.AddWebAPI<IAuthServiceAPI>();

            return services;
        }
    }
}
