using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities.ValueObjects;
using System;
using System.Collections.Generic;

namespace EDT.DDD.Sample.API.Domain.PersonAggregate.Entities
{
    /// <summary>
    /// 人员实体
    /// </summary>
    public class Person
    {
        public string PersonId { get; set; }

        public string PersonName { get; set; }

        public PersonType Type { get; set; }

        public PersonStatus Status { get; set; }

        public List<Relationship> Relationships { get; set; }

        public int RoleLevel { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastModifiedTime { get; set; }

        public Person Create()
        {
            Status = PersonStatus.ENABLE;
            CreateTime = DateTime.Now;

            return this;
        }

        public Person Enable()
        {
            Status = PersonStatus.ENABLE;
            LastModifiedTime = DateTime.Now;

            return this;
        }

        public Person Disable()
        {
            Status = PersonStatus.DISABLE;
            LastModifiedTime = DateTime.Now;

            return this;
        }
    }
}
