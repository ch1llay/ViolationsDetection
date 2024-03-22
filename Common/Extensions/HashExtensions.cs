using System.Security.Cryptography;
using System.Text;

namespace Common.Extensions;

public static class HashExtensions
{
    private static readonly byte[] Salt = new byte[64];

    public static string HashString(this string s)
    {
        var sha256Hash = GenerateSha256Hash(s, Salt);

        return Convert.ToBase64String(sha256Hash);
    }

    private static byte[] GenerateSalt()
    {
        const int saltLength = 64;
        var salt = new byte[saltLength];

        var rngRand = RandomNumberGenerator.Create();
        rngRand.GetBytes(salt);

        return salt;
    }

    private static byte[] GenerateSha256Hash(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var saltedPassword = new byte[salt.Length + passwordBytes.Length];

        using var hash = new SHA256CryptoServiceProvider();

        return hash.ComputeHash(saltedPassword);
    }
}