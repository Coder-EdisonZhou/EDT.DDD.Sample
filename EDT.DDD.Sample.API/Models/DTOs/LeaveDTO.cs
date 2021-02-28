using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Models.DTOs
{
    public class LeaveDTO
    {
        public string LeaderId { get; set; }

        public ApplicantDTO Applicant { get; set; }

        public ApproverDTO Approver { get; set; }

        public string LeaveType { get; set; }

        public ApprovalInfoDTO CurrentApprovalInfo { get; set; }

        public List<ApprovalInfoDTO> HistoryApprovalInfos { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public string Status { get; set; }
    }
}
