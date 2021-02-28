using EDT.DDD.Sample.API.Infrastructure.Utils;
using Newtonsoft.Json;
using System;

namespace EDT.DDD.Sample.API.Domain.Common.Events
{
    public class DomainEventBase
    {
        public DomainEventBase()
        {
            Id = IdGenerator.GetInstance().GetUniqueShortId();
            CreateDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public DomainEventBase(string id, DateTime createDate)
        {
            Id = id;
            CreateDate = createDate;
        }

        [JsonProperty]
        public string Id { get; private set; }

        [JsonProperty]
        public DateTime CreateDate { get; private set; }
    }
}
