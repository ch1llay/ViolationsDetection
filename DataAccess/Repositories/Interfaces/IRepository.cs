namespace DataAccess.Repositories.Interfaces;

public interface IRepository<T>
{
    public Task<T> Add(T model);
    public Task<T> Update(T model);
    public Task<bool> Delete(Guid id);
    public Task<IEnumerable<T>> GetByIds(IEnumerable<Guid> ids);
}