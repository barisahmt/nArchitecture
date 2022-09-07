using Application.Features.Coffes.Commands.CreateCoffe;
using Application.Features.Coffes.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Coffes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Coffe, CreatedCoffeDto>().ReverseMap();
            CreateMap<Coffe, CreateCoffeCommand>().ReverseMap();
            


        }
    }
}
