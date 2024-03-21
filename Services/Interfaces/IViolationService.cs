using Services.Models.Violations;

namespace Services.Interfaces;

public interface IViolationService : ICrudService<Violation, Guid>
{
    public Task<List<Violation>> GetByUserId(Guid userId);
}