using System;

namespace EDT.DDD.Sample.API.Infrastructure.POs.Leave
{
    public class ApprovalInfoPO
    {
         public virtual string ApprovalInfoId { get; set; }

         public virtual string LeaderId { get; set; }

         public virtual string ApplicantId { get; set; }

         public virtual string ApproverId { get; set; }

         public virtual int ApproverLevel { get; set; }

         public virtual string ApproverName { get; set; }

         public virtual string Message { get; set; }

         public virtual DateTime Time { get; set; }
    }
}
