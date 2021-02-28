using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Infrastructure.POs.Leave;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Repositories
{
    public interface ILeaveRepository : IRepository<LeavePO>
    {
        void Save(LeavePO leave);

        void SaveEvent(LeaveEventPO leaveEvent);

        LeavePO GetById(string id);

        List<LeavePO> GetByApplicantId(string applicantId);

        List<LeavePO> GetByApproverId(string approverId);
    }
}
