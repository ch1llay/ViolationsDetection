using System.IdentityModel.Tokens.Jwt;

namespace Api;

public class JWTParser
{
    public static T? GetParameter<T>(string jwtInput, string parameterKey) where T : class
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var data = handler.ReadJwtToken(jwtInput.Split(' ')[1]);

            return data.Payload.Claims.FirstOrDefault(c => c.Type == "Email")?.Value as T ?? default(T);
        }
        catch (Exception ex)
        {
            return default;
        }
    }
}
