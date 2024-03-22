using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Auth;

public class AuthOptions
{
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "MyAuthClient"; // потребитель токена
    private const string KEY = "mysupersecret_secretkey!1233434343434343434343434123"; // ключ для шифрации

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}