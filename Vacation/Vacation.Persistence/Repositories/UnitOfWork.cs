using Vacation.Application.Contracts;
using Vacation.Persistence.Data;

namespace Vacation.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IVacationRepository Vacations { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Vacations = new VacationRepository(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int Complete()
        {
           var num= _context.SaveChanges();
            return num;
        }
    }
}
