using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Vacation.Application.Features.Vacation.Commands.CreateVacation
{
    public class CreateVacationCommand:IRequest<Guid>
    {
        [Required]
        [StringLength(100)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(10)]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Department { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
        public string Notes { get; set; }
    }
}
