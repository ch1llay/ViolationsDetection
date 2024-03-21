using Services.Models;

namespace Api.Contracts;

public class AuthResp
{
    public bool Success { get; set; }
    public string AccessToken { get; set; }
    public User User { get; set; }
}