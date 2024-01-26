namespace api.Middleware;

public class GlobalExceptionHandlingMiddleware 
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next, ILogger logger)
    {
         _next = next;
         _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context){
        try
        {
            await _next(context);
        }
        catch(Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = 500; 
            await context.Response.WriteAsJsonAsync(new {problem = "internal"});
        }
    }    
}