using System.Globalization;

namespace ShitShovela
{
    internal class EnvHelper
    {

        internal string? GetString( string key )
        {
            if ( string.IsNullOrWhiteSpace( key ) )
            {
                return null;
            }

            string? value = Environment.GetEnvironmentVariable( key );

            if ( string.IsNullOrWhiteSpace( value ) )
            {
                return null;
            }

            return value;
        }

        internal float? GetFloat( string key )
        {
            string? value = GetString( key );
            if ( value == null )
            {
                return null;
            }
            try
            {
                float parsed_value = float.Parse( value, CultureInfo.InvariantCulture );
                return parsed_value;
            }
            catch ( FormatException )
            {
                Console.WriteLine( $"Couldn't parse value '{value}' as float." );
                return null;
            }
        }

        internal int? GetInt( string key )
        {
            string? value = GetString( key );
            if ( value == null )
            {
                return null;
            }
            try
            {
                int parsed_value = int.Parse( value, CultureInfo.InvariantCulture );
                return parsed_value;
            }
            catch ( FormatException )
            {
                Console.WriteLine( $"Couldn't parse value '{value}' as float." );
                return null;
            }
        }

        internal TimeSpan? GetTimeSpan( string? hourKey, string? minuteKey, string? secondKey )
        {
            int hours = 0;
            int minutes = 0;
            int seconds = 0;

            if ( !string.IsNullOrWhiteSpace( hourKey ) )
            {
                hours = GetInt( hourKey ) ?? hours;
            }
            if ( !string.IsNullOrWhiteSpace( minuteKey ) )
            {
                minutes = GetInt( minuteKey ) ?? minutes;
            }
            if ( !string.IsNullOrWhiteSpace( secondKey ) )
            {
                seconds = GetInt( secondKey ) ?? seconds;
            }

            if ( hours == 0 && minutes == 0 && seconds == 0 )
            {
                return null;
            }

            return new TimeSpan( hours: hours, minutes: minutes, seconds: seconds );
        }
    }
}
