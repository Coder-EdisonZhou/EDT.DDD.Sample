using AutoMapper;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories;
using EDT.DDD.Sample.API.Infrastructure.POs.Person;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Services
{
    public class PersonFactory
    {
        private readonly IPersonRepository _personRepository;

        public PersonFactory(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonPO CreatePersonPO(Person person)
        {
            var personPO = Mapper.Map<PersonPO>(person);
            return personPO;
        }

        public Person CreatePerson(PersonPO personPO)
        {
            var person = Mapper.Map<Person>(personPO);
            return person;
        }

        public Person GetPerson(PersonPO personPO)
        {
            personPO = _personRepository.GetById(personPO.PersonId);
            return CreatePerson(personPO);
        }
    }
}
