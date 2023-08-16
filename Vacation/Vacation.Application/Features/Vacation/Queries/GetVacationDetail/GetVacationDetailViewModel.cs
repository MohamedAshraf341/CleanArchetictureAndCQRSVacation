namespace Vacation.Application.Features.Vacation.Queries.GetVacationDetail
{
    public class GetVacationDetailViewModel
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public DateTime SubmitionDate { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public DateTime Returning { get; set; }
        public double TotalDay { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
    }
}
