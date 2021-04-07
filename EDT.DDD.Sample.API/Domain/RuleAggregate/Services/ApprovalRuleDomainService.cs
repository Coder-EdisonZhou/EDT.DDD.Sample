using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories;
using System;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Services
{
    public class ApprovalRuleDomainService : IApprovalRuleDomainService
    {
        private readonly IApprovalRuleRepository _approvalRuleRepository;
        private readonly ApprovalRuleFactory _approvalRuleFactory;

        public ApprovalRuleDomainService(IApprovalRuleRepository approvalRuleRepository, ApprovalRuleFactory approvalRuleFactory)
        {
            _approvalRuleRepository = approvalRuleRepository ?? throw new ArgumentNullException(nameof(approvalRuleRepository));
            _approvalRuleFactory = approvalRuleFactory ?? throw new ArgumentNullException(nameof(approvalRuleFactory));
        }

        public int GetLeaderMaxLevel(string personType, string leaveType, decimal duration)
        {
            var approvalRule = new ApprovalRule();
            approvalRule.PersonType = personType;
            approvalRule.LeaveType = leaveType;
            approvalRule.Duration = duration;

            return _approvalRuleRepository.GetLeaderMaxLevel(approvalRule);
        }
    }
}
