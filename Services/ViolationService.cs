using AutoMapper;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories;
using Services.Interfaces;
using Services.Models.Violations;

namespace Services;

public class ViolationService(
    IMapper mapper,
    IViolationRepository violationRepository) : IViolationService
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