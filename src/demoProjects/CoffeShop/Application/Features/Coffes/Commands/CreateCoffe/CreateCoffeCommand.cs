using Application.Features.Coffes.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Features.Coffes.Dtos;

namespace Application.Features.Coffes.Commands.CreateCoffe
{
    public class CreateCoffeCommand : IRequest<CreatedCoffeDto>
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public class CreateCoffeCommandHandler : IRequestHandler<CreateCoffeCommand, CreatedCoffeDto>
        {
            private readonly ICoffeRepository _coffeRepository;
            private readonly IMapper _mapper;

            public CreateCoffeCommandHandler(ICoffeRepository coffeRepository, IMapper mapper)
                => (_coffeRepository, _mapper) = (coffeRepository, mapper);


            public async Task<CreatedCoffeDto> Handle(CreateCoffeCommand request, CancellationToken cancellationToken)
            {
                Coffe mappedCoffe = _mapper.Map<Coffe>(request);
                Coffe createdCoffe = await _coffeRepository.AddAsync(mappedCoffe);
                CreatedCoffeDto createdCoffeDto = _mapper.Map<CreatedCoffeDto>(createdCoffe);
                return createdCoffeDto;
            }
        }
    }
}
