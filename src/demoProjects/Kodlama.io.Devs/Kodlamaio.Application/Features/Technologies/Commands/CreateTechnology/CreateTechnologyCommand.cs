using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateTechnology;

public class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
{
    public string Name { get; set; }
    
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
    {
        private ITechnologyRepository _technologyrepository;
        private IMapper _mapper;

        public CreateTechnologyCommandHandler(ITechnologyRepository technologyrepository, IMapper mapper)
        {
            _technologyrepository = technologyrepository;
            _mapper = mapper;
        }

        public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
        {
            
            await _technologyrepository.AddAsync(_mapper.Map<Technology>(request));
            CreatedTechnologyDto createdTechnologyDto =  _mapper.Map<CreatedTechnologyDto>(request);
            return createdTechnologyDto;
        }
    }
}