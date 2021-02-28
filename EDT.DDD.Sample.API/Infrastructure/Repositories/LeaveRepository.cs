using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.Context;
using EDT.DDD.Sample.API.Infrastructure.POs.Leave;
using System;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Infrastructure.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly SampleDbContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public LeaveRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<LeavePO> GetByApplicantId(string applicantId)
        {
            throw new NotImplementedException();
        }

        public List<LeavePO> GetByApproverId(string approverId)
        {
            throw new NotImplementedException();
        }

        public LeavePO GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Save(LeavePO leave)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(LeaveEventPO leaveEvent)
        {
            throw new NotImplementedException();
        }
    }
}
