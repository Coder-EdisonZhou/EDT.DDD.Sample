using AutoMapper;
using EDT.DDD.Sample.API.Application.Services;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;
using EDT.DDD.Sample.API.Models.DTOs;
using EDT.DDD.Sample.API.Models.VOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private const string ErrorMessage = "Internal Server Error, Please wait and retry!";
        private readonly ILogger<AuthController> _logger;
        private readonly IPersonApplicationService _personApplicationService;

        public PersonController(ILogger<AuthController> logger, IPersonApplicationService personApplicationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _personApplicationService = personApplicationService ?? throw new ArgumentNullException(nameof(personApplicationService));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(PersonDTO personDTO)
        {
            var personDO = Mapper.Map<Person>(personDTO);
            try
            {
                await _personApplicationService.Create(personDO);
                return Ok(new { message = "Create Person Success!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create Person Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(PersonDTO personDTO)
        {
            var personDO = Mapper.Map<Person>(personDTO);
            try
            {
                await _personApplicationService.Update(personDO);
                return Ok(new { message = "Update Person Success!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Person Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([Required] string personId)
        {
            try
            {
                await _personApplicationService.DeleteById(personId);
                return Ok(new { message = "Delete Person Success!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete Person Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpGet("{personId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByPersonId([Required] string personId)
        {
            try
            {
                var personDO = _personApplicationService.GetById(personId);
                var personVO = Mapper.Map<PersonVO>(personDO);
                return Ok(new { data = personVO });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Person by ID Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpGet("Find1stApprover")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> FindFirstApprover([Required] string applicantId, int leaderMaxLevel)
        {
            try
            {
                var personDO = _personApplicationService.FindFirstApprover(applicantId, leaderMaxLevel);
                var personVO = Mapper.Map<PersonVO>(personDO);
                return Ok(new { data = personVO });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Find 1st Approver Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }
    }
}
