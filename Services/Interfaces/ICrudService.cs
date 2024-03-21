namespace Services.Interfaces;

public interface ICrudService<T, TId>
{
    public Task<T> Add(T model);
    public Task<T> Update(T model);
    public Task<bool> Delete(TId id);
    public Task<List<T>> GetByIds(IEnumerable<TId> ids);
    public Task<T> GetById(TId id);
}