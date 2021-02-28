using EDT.DDD.Sample.API.Domain.LeaveAggregate.Events;
using System;

namespace EDT.DDD.Sample.API.Infrastructure.POs.Leave
{
    public class LeaveEventPO
    {
        public virtual string Id { get; set; }

        public virtual LeaveEventType EventType { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual string Source { get; set; }

        public virtual string Data { get; set; }
    }
}
