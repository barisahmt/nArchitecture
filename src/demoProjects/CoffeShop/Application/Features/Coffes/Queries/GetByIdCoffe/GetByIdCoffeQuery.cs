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

namespace Application.Features.Coffes.Queries.GetByIdCoffe
{
    public class GetByIdCoffeQuery : IRequest<CoffeGetByIdDto>
    {
        public int Id { get; set; }


        public class GetByIdCoffeQueryHandler : IRequestHandler<GetByIdCoffeQuery, CoffeGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly ICoffeRepository _coffeRepository;

            public GetByIdCoffeQueryHandler(IMapper mapper, ICoffeRepository cofferepository)
                => (_mapper, _coffeRepository) = (mapper, cofferepository);

            public async Task<CoffeGetByIdDto> Handle(GetByIdCoffeQuery request, CancellationToken cancellationToken)
            {
                Coffe? coffe = await _coffeRepository.GetAsync(c=>c.Id == request.Id);

                CoffeGetByIdDto coffeGetByIdDto = _mapper.Map<CoffeGetByIdDto>(coffe);

                return coffeGetByIdDto;
            }
        }
    }
}
