using System.Linq.Expressions;
using Vacation.Application.Contracts;
using Vacation.Domain.Entities;
using Vacation.Persistence.Data;

namespace Vacation.Persistence.Repositories
{
    public class VacationRepository : BaseRepository<VacationRequest>, IVacationRepository
    {
        private readonly ApplicationDbContext _context;
        public VacationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<VacationRequest>> FindAllAsync(Expression<Func<VacationRequest, bool>> criteria, string[] includes = null)
        {
            throw new NotImplementedException();
        }
    }
}
