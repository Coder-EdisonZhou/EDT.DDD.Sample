using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Application.Services
{
    public interface ILeaveApplicationService
    {
        Task CreateLeaveInfo(Leave leave);

        Task UpdateLeaveInfo(Leave leave);

        Task SubmitApproval(Leave leave);

        Leave GetLeaveInfo(string leaveId);

        List<Leave> GetLeaveInfosByApplicant(string applicantId);

        List<Leave> GetLeaveInfosByApprover(string approverId);
    }
}
