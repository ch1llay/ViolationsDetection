namespace Api.Extensions;

public static class HttpContextExtensions
{
    public static string GetToken(this HttpContext context)
    {
        context.Request.Headers.TryGetValue("Authorization", out var token);

        return token;
    }
}