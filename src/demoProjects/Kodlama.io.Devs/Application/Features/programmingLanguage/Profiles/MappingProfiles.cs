﻿using Application.Features.programmingLanguage.Commands.createProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeletedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageCommand>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();


        }
    }
}
