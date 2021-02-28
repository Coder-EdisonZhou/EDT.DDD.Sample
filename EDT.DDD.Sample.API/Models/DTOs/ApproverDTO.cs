using System.ComponentModel.DataAnnotations;

namespace EDT.DDD.Sample.API.Models.DTOs
{
    public class ApproverDTO
    {
        public string PersonId { get; set; }

        [Required]
        public string PersonName { get; set; }
    }
}
