using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitShovela
{
    internal class Configuration
    {
        internal readonly TimeSpan Duration;

        private static TimeSpan GetDurationFromEnv() {
            string duration_minutes = Environment.GetEnvironmentVariable( "DURATION_MINUTES" ) ?? "10";
            try
            {
                Int32 parsed_duration_minutes = Int32.Parse( duration_minutes );
                if (parsed_duration_minutes < 1)
                {
                    throw new ArgumentOutOfRangeException( "Environment variable DURATION_MINUTES must be a positive Int32." );
                }
                return new TimeSpan( hours: 0, minutes: parsed_duration_minutes, seconds: 0 );        
            } catch (FormatException) {
                Console.WriteLine( "Encountered an error when parsing DURATION_MINUTES from Environment. Value must be a positive Int32." );
                throw;
            }
        }

        internal Configuration()
        {
            Duration = GetDurationFromEnv();
        }
    }
}
