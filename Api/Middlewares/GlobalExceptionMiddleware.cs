namespace Api.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = 500;

        return context.Response.WriteAsync(exception.Message);
    }
}