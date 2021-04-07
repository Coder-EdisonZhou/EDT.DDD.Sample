using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.Persistence;
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

        public void Add(Person person)
        {
            _dbContext.Person.Add(person);
        }

        public Person GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Person GetLeaderByPersonId(string personId)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
