using Services.Models.Users;

namespace Services.Interfaces;

public interface IUserService : ICrudService<User, Guid> { }