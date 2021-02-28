using AutoMapper;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.POs.Rule;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Services
{
    public class ApprovalRuleFactory
    {
        private readonly IApprovalRuleRepository _approvalRuleRepository;

        public ApprovalRuleFactory(IApprovalRuleRepository approvalRuleRepository)
        {
            _approvalRuleRepository = approvalRuleRepository;
        }

        public ApprovalRulePO CreateApprovalRulePO(ApprovalRule approvalRule)
        {
            var approvalRulePO = Mapper.Map<ApprovalRulePO>(approvalRule);
            return approvalRulePO;
        }

        public ApprovalRule CreateApprovalRule(ApprovalRulePO approvalRulePO)
        {
            var approvalRule = Mapper.Map<ApprovalRule>(approvalRulePO);
            return approvalRule;
        }
    }
}
