namespace Core.Api.Request.Response.Response;

/// <summary>
/// Represents standardized failure details returned by service operations.
/// </summary>
/// <param name="ErrorCode">HTTP error code. Commonly used to set the HTTP response status code.</param>
/// <param name="ErrorMessage">A short, human-readable message describing the error. The record also exposes a derived <see cref="ErrorMessage"/> property that prefixes this value for consistent display.</param>
/// <param name="FancyError">A user-facing, friendly error message intended for UI display (generic guidance for end users).</param>
/// <param name="DescriptiveError">A machine- or developer-oriented identifier or description for the error (for logging, diagnostics or programmatic checks).</param>
/// <remarks>
/// Each instance includes a unique <see cref="Id"/> for correlation and logging. Prefer placing machine-readable details in
/// <paramref name="DescriptiveError"/> and human-facing messages in <paramref name="FancyError"/> or <paramref name="ErrorMessage"/>.
/// </remarks>
public record FailedResultArgs(int ErrorCode, string ErrorMessage = "Unexpected error has occurred.", string FancyError = "There was a problem. Please, contact with the site administrator", string DescriptiveError = "UNDEFINED")
{
    /// <summary>
    /// A unique correlation identifier generated when the failure instance is created. Useful for tracing and logs.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Derived, formatted error message built from the constructor <c>ErrorMessage</c> parameter.
    /// This property prefixes the original message with "An error has occurred: " to provide consistent presentation.
    /// </summary>
    public string ErrorMessage { get; } = "An error has occurred: " + ErrorMessage;
}