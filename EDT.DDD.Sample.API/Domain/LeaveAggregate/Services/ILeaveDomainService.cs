using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Services
{
    public interface ILeaveDomainService
    {
        Task CreateLeave(Leave leave, int leaderMaxLevel, Approver approver);

        Task UpdateLeaveInfo(Leave leave);

        Task SubmitApproval(Leave leave, Approver approver);

        Leave GetLeaveInfo(string leaveId);

        List<Leave> GetLeaveInfosByApplicant(string applicantId);

        List<Leave> GetLeaveInfosByApprover(string approverId);
    }
}
