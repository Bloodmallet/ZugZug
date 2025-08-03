using ShitShovela;

internal class Program
{
    private async static Task<int> Main( string[] args )
    {
        Console.WriteLine( "Starting" );

        Configuration config = new Configuration();

        DurationTracker tracker = new DurationTracker( config );
        tracker.ExitOnOvertime();

        Console.WriteLine( "Finished processing" );
        return 0;
    }
}
