using Application.Features.Coffes.Commands.CreateCoffe;
using Application.Features.Coffes.Commands.DeleteCoffe;
using Application.Features.Coffes.Commands.UpdateCoffe;
using Application.Features.Coffes.Dtos;
using Application.Features.Coffes.Dtos.Coffes;
using Application.Features.Coffes.Models.Coffe;
using Application.Features.Coffes.Queries.GetByIdCoffe;
using Application.Features.Coffes.Queries.GetListCoffe;
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
            CreateMap<IPaginate<Coffe>, CoffeListModel>().ReverseMap();
            CreateMap<Coffe, GetListCoffeQuary>().ReverseMap();
            CreateMap<Coffe, CoffeListDto>().ReverseMap();
            CreateMap<Coffe, DeletedCoffeDto>().ReverseMap();
            CreateMap<Coffe, DeleteCoffeCommand>().ReverseMap();
            CreateMap<Coffe, CoffeGetByIdDto>().ReverseMap();
            CreateMap<Coffe, GetByIdCoffeQuery>().ReverseMap();
            CreateMap<Coffe, UpdatedCoffeDto>().ReverseMap();
            CreateMap<Coffe, UpdateCoffeCommand>().ReverseMap();





        }
    }
}
