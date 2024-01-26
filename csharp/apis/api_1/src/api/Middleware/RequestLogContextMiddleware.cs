namespace api.Middleware;

using Serilog.Context;

public sealed class RequestLogContextMiddleware {
    private readonly RequestDelegate _next;

    public RequestLogContextMiddleware(RequestDelegate next) {
        _next = next;
    }

    public Task InvokeAsync(HttpContext context) {
        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            return _next(context);
        }

    }
}