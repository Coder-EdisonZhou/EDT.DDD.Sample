using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Infrastructure.POs.Rule;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories
{
    public interface IApprovalRuleRepository : IRepository<ApprovalRulePO>
    {
        int GetLeaderMaxLevel(ApprovalRulePO approvalRule);
    }
}
