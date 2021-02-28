using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects;
using System;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities
{
    public class ApprovalInfo
    {
        public string ApprovalInfoId { get; set; }

        public Approver Approver { get; set; }

        public ApprovalType ApprovalType { get; set; }

        public string Message { get; set; }

        public DateTime Time { get; set; }
    }
}
