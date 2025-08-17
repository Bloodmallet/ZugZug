namespace ShitShovela.Configuration.ProgramConfiguration
{
    internal class ConfigurationFactory : Base.ConfigurationFactory
    {
        internal Configuration Get()
        {
            return new Configuration(
                /// Tedious to add all factories for "subconfigurations" to this file here
                durationTracker: new DurationTracker.ConfigurationFactory().Get()
            );
        }
    }
}
