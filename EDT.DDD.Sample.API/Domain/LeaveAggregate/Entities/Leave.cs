using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects;
using System;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities
{
    /// <summary>
    /// 请假单实体
    /// </summary>
    public class Leave
    {
        public string Id { get; set; }

        public Applicant Applicant { get; set; }

        public Approver Approver { get; set; }

        public LeaveType Type { get; set; }

        public Status Status { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal Duration { get; set; }

        public int LeaderMaxLevel { get; set; }

        public ApprovalInfo CurrentApprovalInfo { get; set; }

        public List<ApprovalInfo> HistoryApprovalInfos { get; set; }

        public decimal GetDuration()
        {
            return (decimal)EndTime.Subtract(StartTime).TotalHours;
        }

        public Leave AddHistoryApprovalInfo(ApprovalInfo approvalInfo)
        {
            if (HistoryApprovalInfos == null)
            {
                HistoryApprovalInfos = new List<ApprovalInfo>();
            }

            HistoryApprovalInfos.Add(approvalInfo);

            return this;
        }

        public Leave Create()
        {
            Status = Status.APPROVING;
            StartTime = DateTime.Now;

            return this;
        }

        public Leave Approve(Approver nextApprover)
        {
            Status = Status.APPROVED;
            Approver = nextApprover;

            return this;
        }

        public Leave Reject(Approver approver)
        {
            Approver = approver;
            Status = Status.REJECTED;
            Approver = null;

            return this;
        }

        public Leave Finish()
        {
            Approver = null;
            Status = Status.APPROVED;
            EndTime = DateTime.Now;
            Duration = GetDuration();

            return this;
        }
    }
}
