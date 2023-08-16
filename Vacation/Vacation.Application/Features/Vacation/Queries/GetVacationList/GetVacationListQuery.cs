using MediatR;

namespace Vacation.Application.Features.Vacation.Queries.GetVacationList
{
    public class GetVacationListQuery : IRequest<List<GetVacationListViewModel>>
    {
    }
}
