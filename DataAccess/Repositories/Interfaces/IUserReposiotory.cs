using DataAccess.Entities;

namespace DataAccess.Repositories.Interfaces;

public interface IUserRepository : IRepository<DbUser>
{
    public Task<DbUser?> GetByLogin(string login);
    public Task<IEnumerable<DbUser>> GetAll();
}