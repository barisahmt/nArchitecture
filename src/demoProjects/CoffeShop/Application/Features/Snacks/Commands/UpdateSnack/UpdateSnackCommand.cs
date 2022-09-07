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

namespace Application.Features.Snacks.Commands.UpdateSnack
{
    public class UpdateSnackCommand : IRequest<UpdatedSnackDto>
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string? Name { get; set; }
        public class UpdateSnackCommandHandler : IRequestHandler<UpdateSnackCommand, UpdatedSnackDto>
        {
            private readonly ISnackRepository _snackRepository;
            private readonly IMapper _mapper;

            public UpdateSnackCommandHandler(ISnackRepository snackRepository, IMapper mapper)

              => (_snackRepository, _mapper) = (snackRepository, mapper);



            public async Task<UpdatedSnackDto> Handle(UpdateSnackCommand request, CancellationToken cancellationToken)
            {
                Snack snack = await _snackRepository.GetAsync(s => s.Id == request.Id);

                if (request.Name != null)
                {
                    snack.Name = request.Name;
                }
                snack.Id = request.Id;

                Snack snacks = await _snackRepository.UpdateAsync(snack);

                UpdatedSnackDto updatedSnackDto = _mapper.Map<UpdatedSnackDto>(snacks);
                return updatedSnackDto;




            }
        }

    }

}

