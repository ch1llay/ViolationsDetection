using AutoMapper;
using DataAccess.Entities;
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