using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.Context;
using EDT.DDD.Sample.API.Infrastructure.POs.Person;
using System;

namespace EDT.DDD.Sample.API.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly SampleDbContext _dbContext;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public PersonRepository(SampleDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Add(PersonPO person)
        {
            _dbContext.Person.Add(person);
        }

        public PersonPO GetById(string id)
        {
            throw new NotImplementedException();
        }

        public PersonPO GetLeaderByPersonId(string personId)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonPO person)
        {
            throw new NotImplementedException();
        }
    }
}
