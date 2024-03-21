using DataAccess.MIgrationsHelpers;

namespace DataAccess.Entities;

[TableOrder(0)]
public class DbUser
{
    [PrimaryKey] public Guid Id { get; set; }

    //[ForeignKey(nameof(DbFileModel), nameof(DbFileModel.Id))]
    public Guid? AvatarFileId { get; set; }

    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Patronymic { get; set; }
    public string? PhoneNumber { get; set; }
    public string Email { get; set; }
}