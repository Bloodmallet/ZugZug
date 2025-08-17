using System.Text;

// hello
namespace ShitShovela.Configuration.Base;

/// <summary>
/// Currently limited to getting configurations information from environment.
/// </summary>
internal class ConfigurationFactory {
    protected string AddPrefix(string key) {
        string replacementCharacter = "_";
        StringBuilder builder = new();

        _ = builder.AppendJoin("_", [
            GetType().Namespace,
            key
        ]);

        return builder
            .ToString()
            .ToUpper()
            .Replace(".", replacementCharacter)
            .Replace("-", replacementCharacter)
            .Replace(" ", replacementCharacter)
            .Replace("_CONFIGURATIONFACTORY_", replacementCharacter);
    }

    protected string? GetString(string key) {
        return Utils.EnvironmentAsTypeParser.GetString(AddPrefix(key));
    }

    protected float? GetFloat(string key) {
        return Utils.EnvironmentAsTypeParser.GetFloat(AddPrefix(key));
    }

    protected int? GetInt(string key) {
        return Utils.EnvironmentAsTypeParser.GetInt(AddPrefix(key));
    }

    protected TimeSpan? GetTimeSpan(string? hourKey, string? minuteKey, string? secondKey) {
        string? prefixedHourKey = hourKey == null ? hourKey : AddPrefix(hourKey);
        string? prefixedMinuteKey = minuteKey == null ? minuteKey : AddPrefix(minuteKey);
        string? prefixedSecondKey = secondKey == null ? secondKey : AddPrefix(secondKey);

        return Utils.EnvironmentAsTypeParser.GetTimeSpan(hourKey: prefixedHourKey, minuteKey: prefixedMinuteKey, secondKey: prefixedSecondKey);
    }
}
