using Services.Interfaces;
using Services.Models.Violations;

namespace Services.Files.Interfaces;

public interface IViolationService : ICrudService<Violation, Guid>
{
    public Task<List<Violation>> GetByUserId(Guid userId);
}