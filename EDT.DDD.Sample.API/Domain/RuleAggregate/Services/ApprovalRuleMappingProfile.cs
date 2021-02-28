using AutoMapper;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;
using EDT.DDD.Sample.API.Infrastructure.POs.Rule;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Services
{
    public class ApprovalRuleMappingProfile : Profile
    {
        public ApprovalRuleMappingProfile()
        {
            // todo: Create Map and ReverseMap between DO and PO for Leave Aggregate
            CreateMap<ApprovalRule, ApprovalRulePO>();
        }
    }
}
