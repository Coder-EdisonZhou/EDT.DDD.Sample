namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Entities
{
    /// <summary>
    /// 组织关系
    /// </summary>
    public class Relationship
    {
        public string Id { get; set; }

        public string PersonId { get; set; }

        public string LeaderId { get; set; }

        public int LeaderLevel { get; set; }
    }
}
