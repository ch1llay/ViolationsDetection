using DataAccess.Entity;

namespace DataAccess.Repositories.Interfaces;

public interface IActionDirectionRepository : IRepository<DbActionDirection>
{
    public Task<IEnumerable<DbActionDirection>> GetByLifeSpheres(List<Guid> lifeSphereIds);
}
