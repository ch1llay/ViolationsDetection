using AutoMapper;
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
    public async Task<Violation> Add(Violation model)
    {
        var recognitionFileIds = new List<Guid>();
        foreach (var fileLink in model.FileLinks)
        {
            var file = await fileService.GetByIdWithContent(fileLink);

            var recognitionResp = await recognitionService.Recognize(new RecognitionReque
            {
                Content = new ByteArrayContent(file.Content)

            });

            if (recognitionResp == null)
            {
                continue;
            }
            
            model.ViolationType = recognitionResp.ViolationType;

            var detectFile = await fileService.Add(new FileModel
            {
                Filename = $"Detect {file.Filename}",
                CreatedDate = DateTime.Now,
                ContentType = file.ContentType,
                Content = await recognitionResp.Content.ReadAsByteArrayAsync()
            });
            
            recognitionFileIds.Add(detectFile.Id);
        }

            
        var violation = (await violationRepository.Add(model.Map<DbViolation>(mapper))).Map<Violation>(mapper);

       
        await violationRepository.AddViolationFiles(model.FileLinks.Select(f => new DbViolationFile
        {
            ViolationId = model.Id,
            FileId = f
        }).ToList());
        
        await violationRepository.AddViolationFiles(recognitionFileIds.Select(f => new DbViolationFile
        {
            ViolationId = model.Id,
            FileId = f
        }).ToList());
        
        return violation;
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
        var res = (await violationRepository.GetByIds(new List<Guid> {id})).Map<Violation>(mapper);
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