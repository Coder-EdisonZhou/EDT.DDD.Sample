using EDT.DDD.Sample.API.Domain.Core.SeedWork;
using EDT.DDD.Sample.API.Infrastructure.POs.Person;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories
{
    public interface IPersonRepository : IRepository<PersonPO>
    {
        void Add(PersonPO person);

        void Update(PersonPO person);

        PersonPO GetById(string id);

        PersonPO GetLeaderByPersonId(string personId);
    }
}
