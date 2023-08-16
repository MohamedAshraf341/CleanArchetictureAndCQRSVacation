using AutoMapper;
using MediatR;
using Vacation.Application.Contracts;

namespace Vacation.Application.Features.Vacation.Queries.GetVacationList
{
    public class GetVacationListQueryHandeler : IRequestHandler<GetVacationListQuery, List<GetVacationListViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetVacationListQueryHandeler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<GetVacationListViewModel>> Handle(GetVacationListQuery request, CancellationToken cancellationToken)
        {
            var allVacation = await _unitOfWork.Vacations.GetAllAsync();
            var dto = _mapper.Map<List<GetVacationListViewModel>>(allVacation);
            return dto;
        }
    }
}
