using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Api.Auth;

public class JWTGenerator
{
    public static string Generate(Dictionary<string, string> values)
    {
        var claims = values.Select(v => new Claim(v.Key, v.Value));

        // создаем JWT-токен
        var jwt = new JwtSecurityToken(
            AuthOptions.ISSUER,
            AuthOptions.AUDIENCE,
            claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));


        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}