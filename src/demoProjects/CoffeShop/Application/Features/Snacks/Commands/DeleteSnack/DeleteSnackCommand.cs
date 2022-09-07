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

namespace Application.Features.Snacks.Commands.DeleteSnack
{
    public class DeleteSnackCommand : IRequest<DeletedSnackDto>
    {
        public int Id { get; set; }

        public class DeleteSnackCommandHandler : IRequestHandler<DeleteSnackCommand, DeletedSnackDto>
        {
            private readonly ISnackRepository _snackRepository;
            private readonly IMapper _mapper;

            public DeleteSnackCommandHandler(ISnackRepository snackRepository, IMapper mapper)
            {
                _snackRepository = snackRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSnackDto> Handle(DeleteSnackCommand request, CancellationToken cancellationToken)
            {
                Snack snack = await _snackRepository.GetAsync(s => s.Id == request.Id);

                Snack deleteSnack = await _snackRepository.DeleteAsync(snack);

                DeletedSnackDto deletedSnackDto = _mapper.Map<DeletedSnackDto>(snack);

                return deletedSnackDto;
            }
        }


    }
}
