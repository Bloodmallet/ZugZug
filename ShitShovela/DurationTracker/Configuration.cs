namespace ShitShovela.DurationTracker;

internal class Configuration {
    /// <summary>
    /// How much time passes between program starts.
    /// </summary>
    internal readonly TimeSpan TimeBetweenStarts = new(hours: 0, minutes: 10, seconds: 0);
    /// <summary>
    /// Fraction of TimeBetweenStarts the program is allowed to utilize.
    /// </summary>
    internal readonly float DurationFraction = 0.9f;

    private void ValidateTimeBetweenStarts(TimeSpan? timeBetweenStarts) {
        if (timeBetweenStarts != null && timeBetweenStarts < TimeSpan.Zero) {
            throw new ArgumentOutOfRangeException("DurationTracker timeBetweenStarts must be set to a value greater than zero.");
        }
    }

    private void ValidateDurationFraction(float? durationFraction) {
        if (durationFraction is not null and (<= 0.0f or >= 1.0f)) {
            throw new ArgumentOutOfRangeException("DurationTracker durationFraction must be set to a float between 0.0 and 1.0 excluding both ends.");
        }
    }

    /// <summary>
    /// I'd like to get rid of this wiring.
    /// - parameter names are just field names with a lowercase starting character
    /// - parameter types are just field types with nullability
    /// - optionally some "Validate<FIELD>" method is implemented and called before assignment
    /// - if parameter value is null, stick to the default field value
    /// 
    /// But how do I make this dynamic in c#?
    /// </summary>
    /// <param name="timeBetweenStarts"></param>
    /// <param name="durationFraction"></param>
    internal Configuration(TimeSpan? timeBetweenStarts, float? durationFraction) {
        ValidateTimeBetweenStarts(timeBetweenStarts);
        TimeBetweenStarts = timeBetweenStarts ?? TimeBetweenStarts;

        ValidateDurationFraction(durationFraction);
        DurationFraction = durationFraction ?? DurationFraction;
    }
}
