using DotNetCore.CAP;
using EDT.DDD.Sample.API.Domain.Common.Events;
using EDT.DDD.Sample.API.Domain.Common.Exceptions;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Events;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Services
{
    public class LeaveDomainService : ILeaveDomainService
    {
        private readonly ICapPublisher _eventPublisher;
        private readonly ILeaveRepository _leaveRepository;
        private readonly LeaveFactory _leaveFactory;

        public LeaveDomainService(ICapPublisher eventPublisher, ILeaveRepository leaveRepository, LeaveFactory leaveFactory)
        {
            _eventPublisher = eventPublisher ?? throw new ArgumentNullException(nameof(eventPublisher));
            _leaveRepository = leaveRepository ?? throw new ArgumentNullException(nameof(leaveRepository));
            _leaveFactory = leaveFactory ?? throw new ArgumentNullException(nameof(leaveFactory));
        }

        public async Task CreateLeave(Leave leave, int leaderMaxLevel, Approver approver)
        {
            leave.LeaderMaxLevel = leaderMaxLevel;
            leave.Approver = approver;
            leave.Create();

            _leaveRepository.Save(_leaveFactory.CreateLeavePO(leave));

            var leaveEvent = new LeaveEvent(LeaveEventType.CREATE_EVENT, leave);
            _leaveRepository.SaveEvent(_leaveFactory.CreateLeaveEventPO(leaveEvent));

            var successCount = await _leaveRepository.UnitOfWork.SaveChangesAsync();
            if (successCount > 0)
            {
                _eventPublisher.Publish(DomainEventKeys.LeaveCreatedEventKey, leaveEvent);
            }
        }

        public async Task UpdateLeaveInfo(Leave leave)
        {
            var leavePO = _leaveRepository.GetById(leave.Id);
            if (leavePO == null)
            {
                throw new SampleDomainException("Leave does not exists!");
            }

            _leaveRepository.Save(_leaveFactory.CreateLeavePO(leave));
            await _leaveRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task SubmitApproval(Leave leave, Approver approver)
        {
            LeaveEvent leaveEvent = null;
            string eventKey = string.Empty;
            if (leave.CurrentApprovalInfo.ApprovalType == ApprovalType.REJECT)
            {
                eventKey = DomainEventKeys.LeaveRejectedEventKey;
                leave.Reject(approver);
                leaveEvent = new LeaveEvent(LeaveEventType.REJECT_EVENT, leave);
            }
            else
            {
                if (approver == null)
                {
                    eventKey = DomainEventKeys.LeaveNeedsAgreeEventKey;
                    leave.Approve(approver);
                    leaveEvent = new LeaveEvent(LeaveEventType.AGREE_EVENT, leave);
                }
                else
                {
                    eventKey = DomainEventKeys.LeaveApprovedEventKey;
                    leave.Finish();
                    leaveEvent = new LeaveEvent(LeaveEventType.APPROVED_EVENT, leave);
                }
            }

            leave.AddHistoryApprovalInfo(leave.CurrentApprovalInfo);

            _leaveRepository.Save(_leaveFactory.CreateLeavePO(leave));
            _leaveRepository.SaveEvent(_leaveFactory.CreateLeaveEventPO(leaveEvent));
            var successCount = await _leaveRepository.UnitOfWork.SaveChangesAsync();

            if (successCount > 0)
            {
                _eventPublisher.Publish(eventKey, leaveEvent);
            }
        }

        public Leave GetLeaveInfo(string leaveId)
        {
            var leavePO = _leaveRepository.GetById(leaveId);
            return _leaveFactory.GetLeave(leavePO);
        }

        public List<Leave> GetLeaveInfosByApplicant(string applicantId)
        {
            var leavePOs = _leaveRepository.GetByApplicantId(applicantId);
            return _leaveFactory.GetLeaves(leavePOs);
        }

        public List<Leave> GetLeaveInfosByApprover(string approverId)
        {
            var leavePOs = _leaveRepository.GetByApproverId(approverId);
            return _leaveFactory.GetLeaves(leavePOs);
        }
    }
}
