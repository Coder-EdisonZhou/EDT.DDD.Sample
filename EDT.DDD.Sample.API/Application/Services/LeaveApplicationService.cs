using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Services;
using EDT.DDD.Sample.API.Domain.PersonAggregate.Services;
using EDT.DDD.Sample.API.Domain.RuleAggregate.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Application.Services
{
    public class LeaveApplicationService : ILeaveApplicationService
    {
        private readonly ILeaveDomainService _leaveDomainService;
        private readonly IPersonDomainService _personDomainService;
        private readonly IApprovalRuleDomainService _approvalRuleDomainService;

        public LeaveApplicationService(ILeaveDomainService leaveDomainService, IPersonDomainService personDomainService, IApprovalRuleDomainService approvalRuleDomainService)
        {
            _leaveDomainService = leaveDomainService ?? throw new ArgumentNullException(nameof(leaveDomainService));
            _personDomainService = personDomainService ?? throw new ArgumentNullException(nameof(personDomainService));
            _approvalRuleDomainService = approvalRuleDomainService ?? throw new ArgumentNullException(nameof(approvalRuleDomainService));
        }

        public async Task CreateLeaveInfo(Leave leave)
        {
            var leaderMaxLevel = _approvalRuleDomainService.GetLeaderMaxLevel(
                leave.Applicant.PersonType,
                leave.Type.ToString(),
                leave.GetDuration());
            var approver = _personDomainService.FindFirstApprover(leave.Applicant.PersonId, leaderMaxLevel);
            await _leaveDomainService.CreateLeave(leave, leaderMaxLevel, Approver.FromPerson(approver));
        }

        public Leave GetLeaveInfo(string leaveId)
        {
            return _leaveDomainService.GetLeaveInfo(leaveId);
        }

        public List<Leave> GetLeaveInfosByApplicant(string applicantId)
        {
            return _leaveDomainService.GetLeaveInfosByApplicant(applicantId);
        }

        public List<Leave> GetLeaveInfosByApprover(string approverId)
        {
            return _leaveDomainService.GetLeaveInfosByApprover(approverId);
        }

        public async Task SubmitApproval(Leave leave)
        {
            var approver = _personDomainService.FindNextApprover(
                leave.Approver.PersonId,
                leave.LeaderMaxLevel);
            await _leaveDomainService.SubmitApproval(leave, Approver.FromPerson(approver));
        }

        public async Task UpdateLeaveInfo(Leave leave)
        {
            await _leaveDomainService.UpdateLeaveInfo(leave);
        }
    }
}
