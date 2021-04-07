using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        void Add(Person person);

        void Update(Person person);

        Person GetById(string id);

        Person GetLeaderByPersonId(string personId);
    }
}
