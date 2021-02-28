using EDT.DDD.Sample.API.Models.DTOs;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;

namespace EDT.DDD.Sample.API.Application.APIs
{
    public interface IAuthServiceAPI : IHttpApi
    {
        [JsonReturn]
        [HttpPost("/auth/v1/login")]
        Task<bool> Login([JsonContent] UserDTO user);
    }
}
