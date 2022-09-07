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

namespace Application.Features.Coffes.Commands.CreateSnack
{
    public class CreateSnackCommand : IRequest<CreatedSnackDto>
    {
        public int Id { get; set; }

        public class CreateSnackCommandHandler :IRequestHandler<CreateSnackCommand , CreatedSnackDto>
        {
            private readonly ISnackRepository _snackRepository;
            private readonly IMapper _mapper;

            public CreateSnackCommandHandler(ISnackRepository snackRepository, IMapper mapper)
            {
                _snackRepository = snackRepository;
                _mapper = mapper;
            }
            public async Task<CreatedSnackDto> Handle(CreateSnackCommand request, CancellationToken cancellationToken)
            {
               Snack mappedSnack = _mapper.Map<Snack>(request);
               Snack createdSnack = await _snackRepository.AddAsync(mappedSnack);
                CreatedSnackDto createdSnackDto = _mapper.Map<CreatedSnackDto>(createdSnack);
                return createdSnackDto; 
            }
        }
    }
}
