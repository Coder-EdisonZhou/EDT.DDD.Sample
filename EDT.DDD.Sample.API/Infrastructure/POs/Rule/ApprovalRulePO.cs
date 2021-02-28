namespace EDT.DDD.Sample.API.Infrastructure.POs.Rule
{
    public class ApprovalRulePO
    {
        public virtual string PersonType { get; set; }

        public virtual string LeaveType { get; set; }

        public virtual decimal Duration { get; set; }

        public virtual int MaxLeaderLevel { get; set; }
    }
}
