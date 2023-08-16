using MediatR;

namespace Vacation.Application.Features.Vacation.Queries.GetVacationDetail
{
    public class GetVacationDetailQuery:IRequest<GetVacationDetailViewModel>
    {
        public Guid Id { get; set; }

    }
}
