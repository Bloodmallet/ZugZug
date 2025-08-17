namespace ShitShovela.Configuration.ProgramConfiguration
{
    internal class ConfigurationFactory : Base.ConfigurationFactory
    {
        internal Configuration Get()
        {
            return new Configuration(
                durationTracker: new DurationTracker.ConfigurationFactory().Get()
            );
        }
    }
}
