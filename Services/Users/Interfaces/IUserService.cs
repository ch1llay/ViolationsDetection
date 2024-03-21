using Services.Interfaces;
using Services.Models.Users;

namespace Services.Files.Interfaces;

public interface IUserService : ICrudService<User, Guid> { }