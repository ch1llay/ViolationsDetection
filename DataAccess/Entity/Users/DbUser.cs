using DataAccess.MigrationsHelpers;

namespace DataAccess.Entity.Users;

public class DbUser
{
    [ColumnKey] public Guid Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}