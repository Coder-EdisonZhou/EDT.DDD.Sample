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

            _personRepository.Add(person);
            await _personRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task Update(Person person)
        {
            person.LastModifiedTime = DateTime.Now;
            _personRepository.Update(person);
            await _personRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task DeleteById(string personId)
        {
            var person = _personRepository.GetById(personId);
            person.Disable();
            _personRepository.Update(person);
            await _personRepository.UnitOfWork.SaveChangesAsync();
        }

        public Person GetById(string personId)
        {
            var person = _personRepository.GetById(personId);
            return person;
        }

        public Person FindFirstApprover(string applicantId, int leaderMaxLevel)
        {
            var leader = _personRepository.GetLeaderByPersonId(applicantId);
            if (leader.RoleLevel > leaderMaxLevel)
            {
                return null;
            }
            else
            {
                return leader;
            }
        }

        public Person FindNextApprover(string currentApproverId, int leaderMaxLevel)
        {
            var leader = _personRepository.GetLeaderByPersonId(currentApproverId);
            if (leader.RoleLevel > leaderMaxLevel)
            {
                return null;
            }
            else
            {
                return leader;
            }
        }
    }
}
