using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities.ValueObjects;
using System;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Infrastructure.POs.Leave
{
    public class LeavePO
    {
        public string Id { get; set; }

        public string ApplicantId { get; set; }

        public string ApplicantName { get; set; }

        public PersonType ApplicantType { get; set; }

        public string ApproverId { get; set; }

        public string ApproverName { get; set; }

        public LeaveType LeaveType { get; set; }

        public Status Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Duration { get; set; }

        public List<ApprovalInfoPO> HistoryApprovalInfos { get; set; }
    }
}
