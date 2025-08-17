namespace ShitShovela.DurationTracker
{
    internal class ConfigurationFactory : ShitShovela.Configuration.Base.ConfigurationFactory
    {
        internal Configuration Get()
        {
            return new Configuration(
                timeBetweenStarts: GetTimeSpan(
                    hourKey: null,
                    minuteKey: "MINUTES_BETWEEN_STARTS",
                    secondKey: null
                ),
                durationFraction: GetFloat( "DURATION_FRACTION" )
            );
        }
    }
}
