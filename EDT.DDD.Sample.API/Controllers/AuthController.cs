using AutoMapper;
using EDT.DDD.Sample.API.Application.Services;
using EDT.DDD.Sample.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly ILoginApplicationService _loginApplicationService;

        public AuthController(ILogger<AuthController> logger, ILoginApplicationService loginApplicationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _loginApplicationService = loginApplicationService ?? throw new ArgumentNullException(nameof(loginApplicationService));
        }

        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login(PersonDTO personDTO)
        {
            var userDTO = Mapper.Map<UserDTO>(personDTO);
            bool isAuthed;
            try
            {
                isAuthed = await _loginApplicationService.Login(userDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Auth API Error!");
                return BadRequest(new { message = "Login Server Error, Please wait and retry!" });
            }

            if (isAuthed)
            {
                return Ok(new { message = "Login Success!" });
            }
            else
            {
                return BadRequest(new { message = "Login Failed!" });
            }
        }
    }
}
