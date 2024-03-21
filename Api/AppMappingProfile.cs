using AutoMapper;
using DataAccess.Entities.Files;
using DataAccess.Entities.Users;
using DataAccess.Entities.Violations;
using Services.Models.Files;
using Services.Models.Users;
using Services.Models.Violations;

namespace Api;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<DbUser, User>().ReverseMap();
        CreateMap<DbViolation, Violation>().ReverseMap();
        CreateMap<DbFileContainer, FileContainer>().ReverseMap();
    }
}