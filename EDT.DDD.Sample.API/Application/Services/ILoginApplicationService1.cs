using EDT.DDD.Sample.API.Models.DTOs;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Application.Services
{
    public interface ILoginApplicationService
    {
        Task<bool> Login(UserDTO user);
    }
}
