using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Services
{
    public interface IPersonDomainService
    {
        Task Create(Person person);

        Task Update(Person person);

        Task DeleteById(string personId);

        Person GetById(string personId);

        Person FindFirstApprover(string applicantId, int leaderMaxLevel);

        Person FindNextApprover(string currentApproverId, int leaderMaxLevel);
    }
}
