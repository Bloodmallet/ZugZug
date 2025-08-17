namespace ShitShovela.Configuration.ProgramConfiguration
{
    internal class Configuration
    {
        internal readonly DurationTracker.Configuration DurationTracker;

        internal Configuration( DurationTracker.Configuration durationTracker )
        {
            DurationTracker = durationTracker;
        }
    }
}
