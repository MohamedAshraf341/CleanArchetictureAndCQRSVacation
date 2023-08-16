using MediatR;

namespace Vacation.Application.Features.Vacation.Commands.UpdateVacation
{
    public class UpdateVacationCommand : IRequest
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
