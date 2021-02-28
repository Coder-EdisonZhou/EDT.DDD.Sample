using AutoMapper;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Services;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Services;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Services;
using EDT.DDD.Sample.API.Models.Mappings;
using Microsoft.AspNetCore.Builder;

namespace EDT.DDD.Sample.API.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder IntializeMappingProfiles(this IApplicationBuilder app)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ApplicationMappingProfile>();
                cfg.AddProfile<LeaveMappingProfile>();
                cfg.AddProfile<PersonMappingProfile>();
                cfg.AddProfile<ApprovalRuleMappingProfile>();
            });

            return app;
        }
    }
}
