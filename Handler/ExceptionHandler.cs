using Serilog;
using System.Text;

namespace Core.API.Request.Response.Handler;

/// <summary>
/// Helper class that centralizes exception logging for the application.
/// </summary>
/// <remarks>
/// This class provides a simple, static helper to persist exception information using Serilog to a file
/// (configured to write to "logs/log.txt" with daily rolling). Note that each call to <see cref="LogException(System.Exception)"/>
/// reconfigures <c>Log.Logger</c> and therefore overwrites any previously configured global logger. For production scenarios,
/// prefer configuring Serilog once at application startup and use a logger instance or <c>Log</c> directly.
/// </remarks>
public class ExceptionHandler
{
    /// <summary>
    /// Logs the provided exception to the configured Serilog sink (file "logs/log.txt") including type, message,
    /// stack trace and a UTC timestamp.
    /// </summary>
    /// <param name="e">The exception to log. This parameter must not be <c>null</c>.</param>
    /// <remarks>
    /// This method configures <c>Log.Logger</c> with a <see cref="LoggerConfiguration"/> that writes to a rolling file,
    /// then writes the formatted exception detail produced by <see cref="BuildLog(System.Exception)"/> at error level.
    /// Passing <c>null</c> for <paramref name="e"/> will result in a <see cref="NullReferenceException"/> when the method attempts
    /// to access exception members. Consider validating input or configuring Serilog at application startup for better control.
    /// </remarks>
    public static void LogException(System.Exception e)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Error(BuildLog(e));
    }

    private static string BuildLog(System.Exception e)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("---------------------------------------------------------");
        stringBuilder.AppendLine("---------------------------------------------------------");

        stringBuilder.AppendLine($"Time: {DateTime.UtcNow} UTC.");

        stringBuilder.AppendLine($"Exception threw: {e.GetType()}");
        stringBuilder.AppendLine($"Message: {e.Message}");
        stringBuilder.AppendLine($"Stacktrace: {e.StackTrace}");

        return stringBuilder.ToString();
    }
}