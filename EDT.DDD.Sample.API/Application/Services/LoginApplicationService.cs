using EDT.DDD.Sample.API.Application.APIs;
using EDT.DDD.Sample.API.Models.DTOs;
using System;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Application.Services
{
    public class LoginApplicationService : ILoginApplicationService
    {
        private readonly IAuthServiceAPI _authServiceAPI;

        public LoginApplicationService(IAuthServiceAPI authServiceAPI)
        {
            _authServiceAPI = authServiceAPI ?? throw new ArgumentNullException(nameof(authServiceAPI));
        }

        public async Task<bool> Login(UserDTO user)
        {
            return await _authServiceAPI.Login(user);
        }
    }
}
