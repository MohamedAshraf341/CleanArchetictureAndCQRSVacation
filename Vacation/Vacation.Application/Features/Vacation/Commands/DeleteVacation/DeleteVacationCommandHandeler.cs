using MediatR;
using Vacation.Application.Contracts;

namespace Vacation.Application.Features.Vacation.Commands.DeleteVacation
{
    public class DeleteVacationCommandHandeler : IRequestHandler<DeleteVacationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteVacationCommandHandeler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteVacationCommand request, CancellationToken cancellationToken)
        {
            var vacation=await _unitOfWork.Vacations.GetByIdAsync(request.Id);
            await _unitOfWork.Vacations.DeleteAsync(vacation);
            return Unit.Value;
        }
    }
}
