namespace Services.Models;

public class User
{
    public Guid Id { get; set; }
    public Guid AvatarFileId { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}