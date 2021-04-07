using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories
{
    public interface IApprovalRuleRepository : IRepository<ApprovalRule>
    {
        int GetLeaderMaxLevel(ApprovalRule approvalRule);
    }
}
