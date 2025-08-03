using System.Globalization;

namespace ShitShovela
{
    internal class Configuration
    {
        /// <summary>
        /// Maximum time the application is allowed to last.
        /// </summary>
        internal readonly TimeSpan MaxDuration;
        /// <summary>
        /// Fraction of MaxDuration the program is allowed to utilize.
        /// </summary>
        internal readonly float DurationFraction;

        private static TimeSpan GetMaxDurationFromEnv()
        {
            string duration_minutes = Environment.GetEnvironmentVariable( "DURATION_MINUTES" ) ?? "10";
            try
            {
                Int32 parsed_duration_minutes = Int32.Parse( duration_minutes );
                if ( parsed_duration_minutes < 1 )
                {
                    throw new ArgumentOutOfRangeException( "Environment variable DURATION_MINUTES must be a positive Int32." );
                }
                return new TimeSpan( hours: 0, minutes: parsed_duration_minutes, seconds: 0 );
            }
            catch ( FormatException )
            {
                Console.WriteLine( "Encountered an error when parsing DURATION_MINUTES from Environment. Value must be a positive Int32." );
                throw;
            }
        }

        private static float GetDurationBufferFractionFromEnv()
        {
            // Default: 10%
            string duration_buffer_fraction = Environment.GetEnvironmentVariable( "DURATION_BUFFER_FRACTION" ) ?? "0.1";
            try
            {
                float parsed_duration_buffer_fraction = float.Parse( duration_buffer_fraction, CultureInfo.InvariantCulture );
                if ( ( parsed_duration_buffer_fraction <= 0.0 ) || ( 1.0 <= parsed_duration_buffer_fraction ) )
                {
                    throw new ArgumentOutOfRangeException( "Environment variable DURATION_BUFFER_FRACTION must be a float between 0.0 and 1.0 excluding both ends." );
                }
                return parsed_duration_buffer_fraction;
            }
            catch ( FormatException )
            {
                Console.WriteLine( "Encountered an error when parsing DURATION_BUFFER_FRACTION from Environment. Value must be a float between 0.0 and 1.0 excluding both ends." );
                throw;
            }
        }


        internal Configuration()
        {
            MaxDuration = GetMaxDurationFromEnv();
            DurationFraction = GetDurationBufferFractionFromEnv();
        }
    }
}
