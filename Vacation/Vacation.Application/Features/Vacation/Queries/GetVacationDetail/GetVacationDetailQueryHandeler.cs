using AutoMapper;
using MediatR;
using Vacation.Application.Contracts;

namespace Vacation.Application.Features.Vacation.Queries.GetVacationDetail
{
    public class GetVacationDetailQueryHandeler : IRequestHandler<GetVacationDetailQuery, GetVacationDetailViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetVacationDetailQueryHandeler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        async Task<GetVacationDetailViewModel> IRequestHandler<GetVacationDetailQuery, GetVacationDetailViewModel>.Handle(GetVacationDetailQuery request, CancellationToken cancellationToken)
        {
            var vacation = await _unitOfWork.Vacations.GetByIdAsync(request.Id);
            var dto = _mapper.Map<GetVacationDetailViewModel>(vacation);
            return dto;
        }
    }
}
