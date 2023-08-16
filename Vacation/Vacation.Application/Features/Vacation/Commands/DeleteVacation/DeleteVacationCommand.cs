using MediatR;

namespace Vacation.Application.Features.Vacation.Commands.DeleteVacation
{
    public class DeleteVacationCommand:IRequest
    {
        public Guid Id { get; set; }
    }
}
