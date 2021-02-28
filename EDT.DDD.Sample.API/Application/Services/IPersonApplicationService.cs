using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Application.Services
{
    public interface IPersonApplicationService
    {
        Task Create(Person person);

        Task Update(Person person);

        Task DeleteById(string personId);

        Person GetById(string personId);

        Person FindFirstApprover(string applicantId, int leaderMaxLevel);

        Person FindNextApprover(string approverId, int leaderMaxLevel);
    }
}
