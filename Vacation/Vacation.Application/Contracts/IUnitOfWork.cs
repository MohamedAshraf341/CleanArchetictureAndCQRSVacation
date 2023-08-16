namespace Vacation.Application.Contracts
{
    public interface IUnitOfWork
    {
        IVacationRepository Vacations { get; }
        int Complete();
    }
}
