namespace ShitShovela.Configuration.ProgramConfiguration;

internal class Configuration
{
    /// <summary>
    /// Tedious to add all "subconfigurations" to this file here three times
    /// </summary>
    internal readonly DurationTracker.Configuration DurationTracker;

    internal Configuration( DurationTracker.Configuration durationTracker )
    {
        DurationTracker = durationTracker;
    }
}
