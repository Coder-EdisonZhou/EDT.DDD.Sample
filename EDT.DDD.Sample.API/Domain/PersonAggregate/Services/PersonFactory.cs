using EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Services
{
    public class PersonFactory
    {
        private readonly IPersonRepository _personRepository;

        public PersonFactory(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
    }
}
