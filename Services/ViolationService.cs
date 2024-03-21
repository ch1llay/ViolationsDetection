using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class ViolationService(
    IMapper mapper,
    IViolationRepository violationRepository,
    IFileContainerService fileContainerService) : IViolationService
{
    public async Task<Violation> Add(Violation model)
    {
        return (await violationRepository.Add(model.Map<DbViolation>(mapper))).Map<Violation>(mapper);
    }

    public async Task<Violation> Update(Violation model)
    {
        return (await violationRepository.Update(model.Map<DbViolation>(mapper))).Map<Violation>(mapper);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await violationRepository.Delete(id);
    }

    public async Task<List<Violation>> GetByIds(IEnumerable<Guid> ids)
    {
        var res = (await violationRepository.GetByIds(ids)).MapToList<Violation>(mapper);

        return res;
    }

    public async Task<Violation> GetById(Guid id)
    {
        var res = (await violationRepository.GetByIds(new List<Guid> {id})).Map<Violation>(mapper);

        return res;
    }

    public async Task<List<Violation>> GetByUserId(Guid userId)
    {
        var res = (await violationRepository.GetByUserId(new List<Guid> {userId})).MapToList<Violation>(mapper);

        return res;
    }
}

public static class ViolationExtensions
{
    public static async Task<Violation> GetFiles(this Violation violation,
        IFileContainerService fileContainerService)
    {
        var fileContainer = await fileContainerService.GetByViolationId(violation.Id);
        violation.FileContainer = fileContainer;

        return violation;
    }
    
    public static async Task<List<Violation>> GetFiles(this List<Violation> violations,
        IFileContainerService fileContainerService)
    {
        var violationIds = violations.Select(f => f.Id).ToList();
        var fileContainers = await fileContainerService.GetByViolationIds(violationIds);
        var fileContainersByViolationId = fileContainers.GroupBy(f => f.ViolationId).ToDictionary(t => t.Key, t => t.FirstOrDefault());
        
        violations.ForEach(f=>f.FileContainer = fileContainersByViolationId.GetValueOrDefault(f.Id) ?? new FileContainer());

        return violations;
    }
}