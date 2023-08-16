namespace Vacation.Application.Features.Vacation.Queries.GetVacationList
{
    public class GetVacationListViewModel
    {
        public Guid Id { get; set; }
        public DateTime SubmitionDate { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
