using ShitShovela.DurationTracker;

internal class Program
{
    private async static Task<int> Main( string[] args )
    {
        Console.WriteLine( "Starting" );

        var configuration = new ShitShovela.Configuration.ProgramConfiguration.ConfigurationFactory().Get();
        var tracker = new DurationTracker( configuration.DurationTracker );
        tracker.ExitOnOvertime();

        Console.WriteLine( tracker.MaxRuntimeDuration );
        Console.WriteLine( configuration.DurationTracker.TimeBetweenStarts );
        Console.WriteLine( configuration.DurationTracker.DurationFraction );

        Console.WriteLine( "Finished" );
        return 0;
    }
}
