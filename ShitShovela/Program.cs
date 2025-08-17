using ShitShovela.DurationTracker;

internal class Program {
    private static int Main(string[] args) {
        Console.WriteLine("Starting");

        ShitShovela.Configuration.ProgramConfiguration.Configuration configuration = new ShitShovela.Configuration.ProgramConfiguration.ConfigurationFactory().Get();
        DurationTracker tracker = new(configuration.DurationTracker);
        tracker.ExitOnOvertime();

        Console.WriteLine(tracker.MaxRuntimeDuration);
        Console.WriteLine(configuration.DurationTracker.TimeBetweenStarts);
        Console.WriteLine(configuration.DurationTracker.DurationFraction);

        Console.WriteLine("Finished");
        return 0;
    }
}
