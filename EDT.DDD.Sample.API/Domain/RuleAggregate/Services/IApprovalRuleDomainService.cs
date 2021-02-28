namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Services
{
    public interface IApprovalRuleDomainService
    {
        int GetLeaderMaxLevel(string personType, string leaveType, decimal duration);
    }
}
