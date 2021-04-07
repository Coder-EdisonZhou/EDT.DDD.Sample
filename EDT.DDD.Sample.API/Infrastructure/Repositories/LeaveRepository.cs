using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Events;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.Persistence;
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

        public List<Leave> GetByApplicantId(string applicantId)
        {
            throw new NotImplementedException();
        }

        public List<Leave> GetByApproverId(string approverId)
        {
            throw new NotImplementedException();
        }

        public Leave GetById(string id)
        {
            throw new NotImplementedException();
        }

        public void Save(Leave leave)
        {
            throw new NotImplementedException();
        }

        public void SaveEvent(LeaveEvent leaveEvent)
        {
            throw new NotImplementedException();
        }
    }
}
