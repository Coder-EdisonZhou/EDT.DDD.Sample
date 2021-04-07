using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Entities;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.Persistence;
using System;

namespace EDT.DDD.Sample.API.Infrastructure.Repositories
{
    public class ApprovalRuleRepository : IApprovalRuleRepository
    {
        private readonly SampleDbContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public ApprovalRuleRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public int GetLeaderMaxLevel(ApprovalRule approvalRule)
        {
            throw new NotImplementedException();
        }
    }
}
