using EDT.DDD.Sample.API.Application.APIs;
using EDT.DDD.Sample.API.Application.Services;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Repositories;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Services;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Services;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Services;
using EDT.DDD.Sample.API.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApiClient;

namespace EDT.DDD.Sample.API.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // todo: use autofac to write less DI code
            services.AddScoped<ILoginApplicationService, LoginApplicationService>();
            services.AddScoped<ILeaveApplicationService, LeaveApplicationService>();
            services.AddScoped<IPersonApplicationService, PersonApplicationService>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // todo: use autofac to write less DI code
            services.AddScoped<ILeaveDomainService, LeaveDomainService>();
            services.AddScoped<IPersonDomainService, PersonDomainService>();
            services.AddScoped<IApprovalRuleDomainService, ApprovalRuleDomainService>();
            services.AddScoped<LeaveFactory>();
            services.AddScoped<PersonFactory>();
            services.AddScoped<ApprovalRuleFactory>();

            return services;
        }

        public static IServiceCollection AddInfraRepositories(this IServiceCollection services)
        {
            // todo: use autofac to write less DI code
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IApprovalRuleRepository, ApprovalRuleRepository>();

            return services;
        }

        public static IServiceCollection AddReferencedWebAPIs(this IServiceCollection services)
        {
            services.AddWebAPI<IAuthServiceAPI>();

            return services;
        }

        #region private methods
        private static IServiceCollection AddWebAPI<T>(this IServiceCollection services, string apiHost = null)
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
        #endregion
    }
}
