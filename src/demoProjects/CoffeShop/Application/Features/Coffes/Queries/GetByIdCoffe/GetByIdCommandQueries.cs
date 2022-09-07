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
    public class GetByIdCommandQueries : IRequest<GetByIdCoffeDto>
    {
        public int Id { get; set; }

        public class GetByIdCommandQueriesHandler : IRequestHandler<GetByIdCommandQueries ,GetByIdCoffeDto>
        {
            private readonly IMapper _mapper;
            private readonly ICoffeRepository _coffeRepository;

            public GetByIdCommandQueriesHandler(IMapper mapper, ICoffeRepository coffeRepository)
            {
                _mapper = mapper;
                _coffeRepository = coffeRepository;
            }

            public async Task<GetByIdCoffeDto> Handle(GetByIdCommandQueries request, CancellationToken cancellationToken)
            {
                Coffe? coffe = await _coffeRepository.GetAsync(c => c.Id == request.Id );

                GetByIdCoffeDto getByIdCoffeDto = _mapper.Map<GetByIdCoffeDto>(coffe);
                return getByIdCoffeDto;
            }
        }
    }
}
