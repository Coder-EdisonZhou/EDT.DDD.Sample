using EDT.DDD.Sample.API.Domain.Common.Events;
using EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Events
{
    public class LeaveEvent : DomainEventBase
    {
        public LeaveEventType LeaveEventType { get; }

        public Leave Data { get; }

        public LeaveEvent(LeaveEventType eventType, Leave leave)
        {
            LeaveEventType = eventType;
            Data = leave;
        }
    }
}
