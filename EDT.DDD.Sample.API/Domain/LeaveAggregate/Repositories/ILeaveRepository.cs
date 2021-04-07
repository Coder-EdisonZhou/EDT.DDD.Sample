using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Events;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Repositories
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        void Save(Leave leave);

        void SaveEvent(LeaveEvent leaveEvent);

        Leave GetById(string id);

        List<Leave> GetByApplicantId(string applicantId);

        List<Leave> GetByApproverId(string approverId);
    }
}
