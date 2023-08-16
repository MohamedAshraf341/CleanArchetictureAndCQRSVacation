using AutoMapper;
using MediatR;
using Vacation.Application.Contracts;
using Vacation.Application.Helper;
using Vacation.Domain.Entities;

namespace Vacation.Application.Features.Vacation.Commands.UpdateVacation
{
    public class UpdateVacationCommandHnadeler : IRequestHandler<UpdateVacationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateVacationCommandHnadeler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVacationCommand request, CancellationToken cancellationToken)
        {
            var vacation = _mapper.Map<VacationRequest>(request);
            var validator = new UpdateVacationValidator();
            var result = await validator.ValidateAsync(request);
            if (result.Errors.Any())
            {
                throw new Exception("Vacation is not valid");
            }
            vacation.SubmitionDate = DateTime.UtcNow;
            vacation.Returning = ExtentionDate.GetReturningDate(request.To);
            vacation.TotalDay = ExtentionDate.TotalDays(request.From,request.To);
            await _unitOfWork.Vacations.UpdateAsync(vacation);
            return Unit.Value;
        }
        
    }
}
