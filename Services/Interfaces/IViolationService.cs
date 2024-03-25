using Services.Models;

namespace Services.Interfaces;

public interface IViolationService : ICrudService<Violation, Guid>
{
    public Task<Violation> AddWithToken(Violation model, string auth);
    public Task<List<Violation>> GetByUserId(Guid userId);
}