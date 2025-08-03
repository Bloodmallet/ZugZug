namespace ShitShovela
{
    internal class DurationTracker
    {
        /// <summary>
        /// Start time of the application.
        /// </summary>
        internal readonly DateTimeOffset StartTime;
        /// <summary>
        /// Maximum allowed duration of the program.
        /// </summary>
        internal readonly TimeSpan MaxRuntimeDuration;
        private readonly Configuration _configuration;

        internal DurationTracker( Configuration configuration )
        {
            StartTime = DateTimeOffset.Now;
            _configuration = configuration;
            MaxRuntimeDuration = _configuration.MaxDuration * _configuration.DurationFraction;
        }

        /// <summary>
        /// Duration since the start of the application.
        /// </summary>
        /// <returns></returns>
        internal TimeSpan GetDuration()
        {
            return DateTimeOffset.Now - StartTime;
        }

        /// <summary>
        /// True if application duration already passed the allowed duration of the application.
        /// </summary>
        /// <returns></returns>
        internal bool IsOvertime()
        {
            return GetDuration() > MaxRuntimeDuration;
        }

        /// <summary>
        /// Exit program with an error state if MaxRuntimeDuration was exceeded.
        /// </summary>
        internal void ExitOnOvertime()
        {
            if ( IsOvertime() )
            {
                Console.WriteLine( $"Program took too long. Exceeded allowed duration of '{MaxRuntimeDuration}'." );
                Environment.Exit( 1 );
            }
        }
    }
}
