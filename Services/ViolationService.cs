using AutoMapper;
using Common.Enums;
using Common.Extensions;
using DataAccess.Entities;
using DataAccess.Repositories.Interfaces;
using Services.Interactions;
using Services.Interactions.Models;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class ViolationService(
    IMapper mapper,
    IViolationRepository violationRepository,
    IRecognitionService recognitionService,
    IFileService fileService
) : IViolationService
{
    public async Task<Violation> AddWithToken(Violation model, string auth)
    {
        var recognitionFileIds = new List<Guid>();
        foreach (var fileLink in model.FileLinks)
        {
            var file = await fileService.GetByIdWithContent(fileLink);

            var recognitionResp = await recognitionService.Recognize(file, auth);

            if (string.IsNullOrEmpty(recognitionResp.FileLink))
            {
                continue;
            }


            model.CreatedDate = DateTime.Now;
            model.ViolationType = recognitionResp.ViolationTypes?.FirstOrDefault() ?? ViolationType.Incorrect;
            
            if (recognitionResp?.ViolationTypes == null || recognitionResp.ViolationTypes.Count == 0 || model.ViolationType == ViolationType.Incorrect)
            {
                model.ViolationStatus = ViolationStatus.Uncommitted;
                recognitionFileIds.Add(fileLink);
            }
            else
            {
                model.ViolationStatus = ViolationStatus.Committed;
                recognitionFileIds.Add(Guid.Parse(recognitionResp.FileLink));
            }
            
        }

            
        var violation = (await violationRepository.Add(model.Map<DbViolation>(mapper))).Map<Violation>(mapper);
        
        await violationRepository.AddViolationFiles(model.FileLinks.Select(f => new DbViolationFile
        {
            ViolationId = violation.Id,
            FileId = f,
        }).ToList());
        
        await violationRepository.AddViolationFiles(recognitionFileIds.Select(f => new DbViolationFile
        {
            ViolationId = violation.Id,
            FileId = f,
            WithDetect = true
        }).ToList());
        
        return await GetById(violation.Id);
    }

    public Task<Violation> Add(Violation model)
    {
        throw new NotImplementedException();
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
        await res.GetFiles(violationRepository);

        return res;
    }

    public async Task<Violation> GetById(Guid id)
    {
        var res = (await violationRepository.GetByIds(new List<Guid> {id})).FirstOrDefault()?.Map<Violation>(mapper);

        if (res == null)
        {
            return null;
        }
        
        await res.GetFiles(violationRepository);
        
        return res;
    }

    public async Task<List<Violation>> GetByUserId(Guid userId)
    {
        var res = (await violationRepository.GetByUserId(new List<Guid> {userId})).MapToList<Violation>(mapper);
        await res.GetFiles(violationRepository);

        return res;
    }
}

public static class ViolationExtensions
{
    public static async Task<Violation> GetFiles(this Violation violation,
        IViolationRepository violationRepository
        )
    {
        var fileLinks = (await violationRepository.GetViolationFilesByViolationIds( new List<Guid> {violation.Id})).Select(f => f.FileId).ToList();
        violation.FileLinks = fileLinks;

        return violation;
    }

    public static async Task<List<Violation>> GetFiles(this List<Violation> violations,
        IViolationRepository violationRepository)
    {
        var violationIds = violations.Select(f => f.Id).ToList();
        var fileLinks = await violationRepository.GetViolationFilesByViolationIds(violationIds);
        var fileLinksByViolationId = fileLinks
            .GroupBy(f => f.ViolationId)
            .ToDictionary(t => t.Key, t => t.Select(f => f.FileId).ToList());

        violations.ForEach(v => v.FileLinks = fileLinksByViolationId.GetValueOrDefault(v.Id) ?? new List<Guid>());

        return violations;
    }
}