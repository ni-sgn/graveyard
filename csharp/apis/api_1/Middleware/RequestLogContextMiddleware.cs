namespace api.Middleware;

public sealed class RequestLogContextMiddleware{
    private readonly RequestDelegate _next = next;
    public RequestLogContextMiddleware(RequestDelegate next){
        _next = next;
    }

    public Task InvokeAsync(HttpContext context) {
        
    }
}