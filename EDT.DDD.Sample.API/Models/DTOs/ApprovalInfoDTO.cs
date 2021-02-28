namespace EDT.DDD.Sample.API.Models.DTOs
{
    public class ApprovalInfoDTO
    {
        public string ApprovalInfoId { get; set; }

        public ApproverDTO Approver { get; set; }

        public string Message { get; set; }
    }
}
