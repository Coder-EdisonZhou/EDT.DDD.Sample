using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;

namespace EDT.DDD.Sample.API.Domain.RuleAggregate.Entities
{
    public class ApprovalRule
    {
        public string PersonType { get; set; }

        public string LeaveType { get; set; }

        public decimal Duration { get; set; }

        public int MaxLeaderLevel { get; set; }

        public static ApprovalRule GetByLeave(Leave leave)
        {
            var approvalRule = new ApprovalRule();
            approvalRule.PersonType = leave.Applicant.PersonType;
            approvalRule.LeaveType = leave.Type.ToString();
            approvalRule.Duration = leave.GetDuration();

            return approvalRule;
        }
    }
}
