using System.ComponentModel.DataAnnotations;
using EDT.DDD.Sample.API.Infrastructure.Utils;

namespace EDT.DDD.Sample.API.Models.DTOs
{
    public class PersonDTO
    {
        public string PersonId { get; set; } = IdGenerator.GetInstance().GetUniqueShortId();

        [Required(ErrorMessage = "PersonName can't be null!")]
        [MaxLength(10)]
        public string PersonName { get; set; }

        [Required(ErrorMessage = "RoleId can't be null!")]
        public string RoleId { get; set; }

        [Required(ErrorMessage = "PersonType can't be null!")]
        public string PersonType { get; set; }

        [Required(ErrorMessage = "Person's status can't be null!")]
        public string Status { get; set; }
    }
}
