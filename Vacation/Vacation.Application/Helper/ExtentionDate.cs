namespace Vacation.Application.Helper
{
    public static class ExtentionDate
    {
        public static DateTime GetReturningDate(DateTime toDate)
        {
            DateTime validationDateTo = toDate;

            // If the validation date falls on a working day, return it directly
            if (validationDateTo.DayOfWeek != DayOfWeek.Friday && validationDateTo.DayOfWeek != DayOfWeek.Saturday)
            {
                return validationDateTo;
            }

            DateTime returningDate = validationDateTo;

            do
            {
                returningDate = returningDate.AddDays(1);
            }
            while (returningDate.DayOfWeek == DayOfWeek.Friday || returningDate.DayOfWeek == DayOfWeek.Saturday);

            return returningDate;
        }
        public static double TotalDays(DateTime fromDate, DateTime toDate)
        {
            TimeSpan difference = toDate - fromDate;
            return difference.TotalDays;
        }
    }
}
