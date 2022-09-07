using Application.Features.Coffes.Commands.CreateSnack;
using Application.Features.Snacks.Commands.DeleteSnack;
using Application.Features.Snacks.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Snacks.Profiles
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<Snack, CreatedSnackDto>().ReverseMap();
            CreateMap<Snack, CreateSnackCommand>().ReverseMap();
            CreateMap<Snack, DeletedSnackDto>().ReverseMap();
            CreateMap<Snack, DeleteSnackCommand>().ReverseMap();
        }
    }
}
