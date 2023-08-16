using System.Linq.Expressions;
using Vacation.Domain.Entities;
namespace Vacation.Application.Contracts
{
    public interface IVacationRepository : IBaseRepository<VacationRequest>
    {
        Task<IEnumerable<VacationRequest>> FindAllAsync(Expression<Func<VacationRequest, bool>> criteria, string[] includes = null);
    }
}
