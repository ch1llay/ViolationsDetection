using AutoMapper;
using DataAccess.Entities;
using Services.Models;

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