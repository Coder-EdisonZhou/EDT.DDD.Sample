using AutoMapper;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Services;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Services;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Services;
using Microsoft.AspNetCore.Builder;

namespace EDT.DDD.Sample.API.Models.Mappings
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseAutoMapperMappingProfiles(this IApplicationBuilder app)
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
