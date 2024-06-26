﻿using Api.Contracts;
using AutoMapper;
using DataAccess.Entities;
using Services.Models;

namespace Api;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<RegRequest, User>().ReverseMap();

        CreateMap<DbUser, User>().ReverseMap();
        CreateMap<DbViolation, Violation>().ReverseMap();
        CreateMap<DbFile, FileModel>().ReverseMap();
    }
}