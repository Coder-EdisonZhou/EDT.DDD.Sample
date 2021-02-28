using EDT.DDD.Sample.API.Domain.Common.Exceptions;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Repositories;
using System;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Services
{
    public class PersonDomainService : IPersonDomainService
    {
        private readonly IPersonRepository _personRepository;
        private readonly PersonFactory _personFactory;

        public PersonDomainService(IPersonRepository personRepository, PersonFactory personFactory)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
            _personFactory = personFactory ?? throw new ArgumentNullException(nameof(personFactory));
        }

        public async Task Create(Person person)
        {
            var personInDb = _personRepository.GetById(person.PersonId);
            if (personInDb == null)
            {
                throw new SampleDomainException("Person already exists!");
            }

            person.Create();

            _personRepository.Add(_personFactory.CreatePersonPO(person));
            await _personRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task Update(Person person)
        {
            person.LastModifiedTime = DateTime.Now;
            _personRepository.Update(_personFactory.CreatePersonPO(person));
            await _personRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteById(string personId)
        {
            var personPO = _personRepository.GetById(personId);
            var person = _personFactory.GetPerson(personPO);
            person.Disable();
            _personRepository.Update(_personFactory.CreatePersonPO(person));
            await _personRepository.UnitOfWork.SaveChangesAsync();
        }

        public Person GetById(string personId)
        {
            var personPO = _personRepository.GetById(personId);
            return _personFactory.GetPerson(personPO);
        }

        public Person FindFirstApprover(string applicantId, int leaderMaxLevel)
        {
            var leaderPO = _personRepository.GetLeaderByPersonId(applicantId);
            if (leaderPO.RoleLevel > leaderMaxLevel)
            {
                return null;
            }
            else
            {
                return _personFactory.CreatePerson(leaderPO);
            }
        }

        public Person FindNextApprover(string currentApproverId, int leaderMaxLevel)
        {
            var leaderPO = _personRepository.GetLeaderByPersonId(currentApproverId);
            if (leaderPO.RoleLevel > leaderMaxLevel)
            {
                return null;
            }
            else
            {
                return _personFactory.CreatePerson(leaderPO);
            }
        }
    }
}
