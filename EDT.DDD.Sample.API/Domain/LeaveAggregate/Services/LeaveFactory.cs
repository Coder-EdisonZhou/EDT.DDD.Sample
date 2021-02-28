using AutoMapper;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Events;
using EDT.DDD.Sample.API.Infrastructure.POs.Leave;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Services
{
    public class LeaveFactory
    {
        public LeavePO CreateLeavePO(Leave leave)
        {
            var leavePO = Mapper.Map<LeavePO>(leave);

            // todo: some extra operation
            return leavePO;
        }

        public Leave GetLeave(LeavePO leavePO)
        {
            var leave = Mapper.Map<Leave>(leavePO);

            // todo: some extra operation
            return leave;
        }

        public List<Leave> GetLeaves(List<LeavePO> leavePOs)
        {
            var leaves = Mapper.Map<List<Leave>>(leavePOs);

            // todo: some extra operation
            return leaves;
        }

        public LeaveEventPO CreateLeaveEventPO(LeaveEvent leaveEvent)
        {
            var eventPO = Mapper.Map<LeaveEventPO>(leaveEvent);

            // todo: some extra operation
            return eventPO;
        }
    }
}
