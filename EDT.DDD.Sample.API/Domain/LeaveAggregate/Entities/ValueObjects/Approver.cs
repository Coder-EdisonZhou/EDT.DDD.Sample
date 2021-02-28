using EDT.DDD.Sample.API.Domain.PersonAggregate.Entities;

namespace EDT.DDD.Sample.API.Domain.LeaveAggregate.Entities.ValueObjects
{
    public class Approver
    {
        public string PersonId { get; private set; }

        public string PersonName { get; private set; }

        public int Level { get; private set; }

        public static Approver FromPerson(Person person)
        {
            var approver = new Approver();
            approver.PersonId = person.PersonId;
            approver.PersonName = person.PersonName;
            approver.Level = person.RoleLevel;
            return approver;
        }
    }
}
