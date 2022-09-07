using Application.Features.Coffes.Dtos.Coffes;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Coffes.Commands.UpdateCoffe
{
    public class UpdateCoffeCommand:IRequest<UpdatedCoffeDto>
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int Price { get; set; }

        public class UpdateCoffeCommandHandler : IRequestHandler<UpdateCoffeCommand,UpdatedCoffeDto>
        {
            ICoffeRepository _coffeRepository;
            IMapper _mapper;

            public UpdateCoffeCommandHandler(ICoffeRepository coffeRepository, IMapper mapper)
            
              =>  (_coffeRepository,_mapper ) = (coffeRepository, mapper);
            

            public async Task<UpdatedCoffeDto> Handle(UpdateCoffeCommand request, CancellationToken cancellationToken)
            {
                Coffe coffe = await _coffeRepository.GetAsync(c=>c.Id == request.Id);

                if (request.Name != null)
                {
                    coffe.Name = request.Name;
                }

                coffe.Price = request.Price;

                Coffe coffes = await _coffeRepository.UpdateAsync(coffe);

                UpdatedCoffeDto updatedCoffeDto = _mapper.Map<UpdatedCoffeDto>(coffes);
                return updatedCoffeDto;
            }
        }
    }
}
