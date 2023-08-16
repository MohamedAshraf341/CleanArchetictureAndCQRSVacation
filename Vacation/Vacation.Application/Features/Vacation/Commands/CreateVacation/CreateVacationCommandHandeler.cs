using AutoMapper;
using MediatR;
using Vacation.Application.Contracts;
using Vacation.Application.Helper;
using Vacation.Domain.Entities;

namespace Vacation.Application.Features.Vacation.Commands.CreateVacation
{
    internal class CreateVacationCommandHandeler : IRequestHandler<CreateVacationCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateVacationCommandHandeler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateVacationCommand request, CancellationToken cancellationToken)
        {
            var vacation = _mapper.Map<VacationRequest>(request);
            var validator = new CreateVacationValidator();
            var result = await validator.ValidateAsync(request);
            if(result.Errors.Any())
            {
                throw new Exception("Vacation is not valid");
            }
            vacation.SubmitionDate= DateTime.UtcNow;
            vacation.Returning= ExtentionDate.GetReturningDate(request.To);
            vacation.TotalDay = ExtentionDate.TotalDays(request.From, request.To);
            vacation = await _unitOfWork.Vacations.AddAsync(vacation);
            _unitOfWork.Complete();
            return vacation.Id;
        }
       
    }
}
