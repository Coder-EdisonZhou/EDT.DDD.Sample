using AutoMapper;
using EDT.DDD.Sample.API.Application.Services;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Models.DTOs;
using EDT.DDD.Sample.API.Models.VOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaveController : ControllerBase
    {
        private const string ErrorMessage = "Internal Server Error, Please wait and retry!";
        private readonly ILogger<LeaveController> _logger;
        private readonly ILeaveApplicationService _leaveApplicationService;

        public LeaveController(ILogger<LeaveController> logger, ILeaveApplicationService leaveApplicationService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _leaveApplicationService = leaveApplicationService ?? throw new ArgumentNullException(nameof(leaveApplicationService));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(LeaveDTO leaveDTO)
        {
            var leaveDO = Mapper.Map<Leave>(leaveDTO);
            try
            {
                await _leaveApplicationService.CreateLeaveInfo(leaveDO);
                return Ok(new { message = "Create Leave Info Success!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create Leave Info Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(LeaveDTO leaveDTO)
        {
            var leaveDO = Mapper.Map<Leave>(leaveDTO);
            try
            {
                await _leaveApplicationService.UpdateLeaveInfo(leaveDO);
                return Ok(new { message = "Update Leave Info Success!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Update Leave Info Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpPost("submit")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SubmitApproval(LeaveDTO leaveDTO)
        {
            var leaveDO = Mapper.Map<Leave>(leaveDTO);
            try
            {
                await _leaveApplicationService.SubmitApproval(leaveDO);
                return Ok(new { message = "Submit Approval Success!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Submit Approval Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpGet("{leaveId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByLeaveId([Required] string leaveId)
        {
            try
            {
                var leaveDO = _leaveApplicationService.GetLeaveInfo(leaveId);
                var leaveVO = Mapper.Map<LeaveVO>(leaveDO);
                return Ok(new { data = leaveVO });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get Leave by ID Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }

        [HttpGet("query/applicant/{applicantId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(List<LeaveVO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetLeaveInfosByApplicant([Required] string applicantId)
        {
            try
            {
                var leaveDO = _leaveApplicationService.GetLeaveInfosByApplicant(applicantId);
                var leaveVO = Mapper.Map<List<LeaveVO>>(leaveDO);
                return Ok(new { data = leaveVO });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Query Leave Infos By Applicant Error!");
                return BadRequest(new { message = ErrorMessage });
            }
        }
    }
}
