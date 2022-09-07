using Application.Features.Coffes.Dtos;
using Application.Features.Snacks.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Coffes.Commands.DeleteCoffe
{
    public class DeleteCoffeCommand : IRequest<DeletedCoffeDto>
    {
        public int Id { get; set; }

        public class DeleteCoffeCommandHandler : IRequestHandler<DeleteCoffeCommand, DeletedCoffeDto>
        {
            private readonly ICoffeRepository _coffeRepository;
            private readonly IMapper _mapper;

            public DeleteCoffeCommandHandler(ICoffeRepository coffeRepository, IMapper mapper)
            {
                _coffeRepository = coffeRepository;
                _mapper = mapper;
            }

            public async Task<DeletedCoffeDto> Handle(DeleteCoffeCommand request, CancellationToken cancellationToken)
            {

                Coffe coffe = await _coffeRepository .GetAsync(l => l.Id == request.Id);


                Coffe deleteCoffe = await _coffeRepository.DeleteAsync(coffe);

                DeletedCoffeDto deletedCoffeDto = _mapper.Map<DeletedCoffeDto>(deleteCoffe);
                return deletedCoffeDto;
                
            }
        }
    }
}
