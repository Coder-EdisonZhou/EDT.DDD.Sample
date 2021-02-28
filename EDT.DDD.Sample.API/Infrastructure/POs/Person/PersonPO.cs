using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities.ValueObjects;
using System;

namespace EDT.DDD.Sample.API.Infrastructure.POs.Person
{
    public class PersonPO
    {
        public virtual string PersonId { get; set; }

        public virtual string PersonName { get; set; }

        public virtual string DepartmentId { get; set; }

        public virtual PersonType PersonType { get; set; }

        public virtual string LeaderId { get; set; }

        public virtual int RoleLevel { get; set; }

        public virtual DateTime CreateTime { get; set; }

        public virtual DateTime LastModifiedTime { get; set; }

        public virtual PersonStatus Status { get; set; }

        public virtual RelationshipPO Relationship { get; set; }
    }
}
