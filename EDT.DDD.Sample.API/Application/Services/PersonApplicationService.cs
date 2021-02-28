using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Services;
using System;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Application.Services
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonDomainService _personDomainService;

        public PersonApplicationService(IPersonDomainService personDomainService)
        {
            _personDomainService = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
        }

        public async Task Create(Person person)
        {
            await _personDomainService.Create(person);
        }

        public async Task Update(Person person)
        {
            await _personDomainService.Update(person);
        }

        public async Task DeleteById(string personId)
        {
            await _personDomainService.DeleteById(personId);
        }

        public Person GetById(string personId)
        {
            return _personDomainService.GetById(personId);
        }

        public Person FindFirstApprover(string applicantId, int leaderMaxLevel)
        {
            return _personDomainService.FindFirstApprover(applicantId, leaderMaxLevel);
        }

        public Person FindNextApprover(string approverId, int leaderMaxLevel)
        {
            return _personDomainService.FindNextApprover(approverId, leaderMaxLevel);
        }
    }
}
