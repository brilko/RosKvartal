namespace ConfigurationParameters
{
    public class PeriodToLoad
    {
        public int Years { get; set; }
        public int Month { get; set; }
        public int Days { get; set; }

        public DateTime GetStartDate()
        {
            return DateTime
                .Today
                .AddYears(-1 * Years)
                .AddMonths(-1 * Month)
                .AddDays(-1 * Days)
                .ToUniversalTime();
        }
    }
}
