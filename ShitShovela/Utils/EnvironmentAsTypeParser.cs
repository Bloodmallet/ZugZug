using System.Globalization;

namespace ShitShovela.Utils
{
    /// <summary>
    /// Each provided method tries to convert the value of the given `key` to its announced type.
    /// In case the user input is not helping (null or empty string) or there is no environment variable with the given `key`, then null is returned.
    /// If the conversion to the wanted type fails, the method throws an error.
    /// </summary>
    internal static class EnvironmentAsTypeParser
    {
        internal static string? GetString( string key )
        {
            if ( string.IsNullOrWhiteSpace( key ) )
            {
                return null;
            }

            Console.WriteLine( $"Reading environment variable '{key}'." );

            var value = Environment.GetEnvironmentVariable( key );

            if ( string.IsNullOrWhiteSpace( value ) )
            {
                return null;
            }

            return value;
        }

        internal static float? GetFloat( string key )
        {
            var value = GetString( key );
            if ( value == null )
            {
                return null;
            }

            if ( !float.TryParse( value, CultureInfo.InvariantCulture, out float parsedValue ) )
            {
                Console.WriteLine( $"Couldn't parse value of environment key '{key}' as float ." );
                return null;
            }

            return parsedValue;
        }

        internal static int? GetInt( string key )
        {
            var value = GetString( key );
            if ( value == null )
            {
                return null;
            }

            if ( !int.TryParse( value, CultureInfo.InvariantCulture, out int parsedValue ) )
            {
                Console.WriteLine( $"Couldn't parse value of environment key '{key}' as int ." );
                return null;
            }

            return parsedValue;
        }

        internal static TimeSpan? GetTimeSpan( string? hourKey, string? minuteKey, string? secondKey )
        {
            if ( string.IsNullOrWhiteSpace( hourKey ) && string.IsNullOrWhiteSpace( minuteKey ) && string.IsNullOrWhiteSpace( secondKey ) )
            {
                throw new ArgumentException( "At least one of the parameter of GetTimeSpan needs to contain a string." );
            }

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
