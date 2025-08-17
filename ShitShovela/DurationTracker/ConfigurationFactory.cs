namespace ShitShovela.DurationTracker;

/// <summary>
/// I'd like to get rid of this wiring. 
/// - Environment Variable names are class properties/fields converted from upper CamelCase to upper SNAKE_CASE.
/// - Types can either be mapped to matching methods, or get looked up by name "Get<TYPE>"
/// </summary>
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
