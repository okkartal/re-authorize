using System.Net.Http;
using Microsoft.Extensions.Http.Logging;
using Microsoft.Extensions.Logging;

namespace client;

public class CustomLogger : IHttpClientLogger
{
    private readonly ILogger _logger;

    public CustomLogger(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<CustomLogger>();
    }

    public object? LogRequestStart(HttpRequestMessage request)
    {
        _logger.LogInformation(nameof(LogRequestStart));
        return null;
    }

    public void LogRequestStop(object? context, HttpRequestMessage request, HttpResponseMessage response, TimeSpan elapsed)
        => _logger.LogInformation(nameof(LogRequestStop));

    public void LogRequestFailed(object? context, HttpRequestMessage request, HttpResponseMessage? response, Exception exception, TimeSpan elapsed)
        => _logger.LogInformation(nameof(LogRequestFailed));
}
