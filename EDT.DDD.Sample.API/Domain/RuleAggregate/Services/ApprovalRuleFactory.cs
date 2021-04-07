using AutoMapper;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Services
{
    public class ApprovalRuleFactory
    {
        private readonly IApprovalRuleRepository _approvalRuleRepository;

        public ApprovalRuleFactory(IApprovalRuleRepository approvalRuleRepository)
        {
            _approvalRuleRepository = approvalRuleRepository;
        }
    }
}
