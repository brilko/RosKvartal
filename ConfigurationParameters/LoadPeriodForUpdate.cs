namespace ConfigurationParameters
{
    public class LoadPeriodForUpdate
    {
        public int Month { get; set; }
        public int Days { get; set; }
        public int Hour { get; set; }

        public DateTime GetStartDate(DateTime dateTimeOfLastUpdate)
        {
            return dateTimeOfLastUpdate
                .AddMonths(-1 * Month)
                .AddDays(-1 * Days)
                .AddHours(-1 * Hour)
                .ToUniversalTime();
        }
    }
}
