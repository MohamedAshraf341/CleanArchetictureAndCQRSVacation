using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vacation.Domain.Entities.Identity;

namespace Vacation.Domain.Entities
{
    public class VacationRequest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime SubmitionDate { get; set; }
        [Required, MaxLength(100)]
        public string EmployeeName { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(100)]
        public string Department { get; set; }
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }
        [Required]
        public DateTime Returning { get; set; }
        public double TotalDay { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

    }
}