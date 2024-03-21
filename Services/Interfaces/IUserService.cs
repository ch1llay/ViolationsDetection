using Services.Models;
using Services.Models.Users;

namespace Services.Interfaces;

public interface IUserService
{
    public Task<User?> GetByLogin(string login);
    public Task<List<User>> GetAll();
    public Task<User> Add(User user);
    public Task<User> GetById(Guid id);
}
