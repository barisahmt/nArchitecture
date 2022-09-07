using Application.Features.Coffes.Dtos.Coffes;
using Application.Features.Coffes.Models.Coffe;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Coffes.Queries.GetListCoffe
{
    public class GetListCoffeQuary :IRequest<CoffeListModel>
    {
        public  PageRequest PageRequest { get; set; }

        public class GetListCoffeQuaryHandler : IRequestHandler<GetListCoffeQuary, CoffeListModel>
        {
            private readonly ICoffeRepository _coffeRepository;
            private readonly IMapper _mapper;

            public GetListCoffeQuaryHandler(ICoffeRepository coffeRepository, IMapper mapper)
                =>(_coffeRepository,_mapper) =(coffeRepository,mapper);

            public async Task<CoffeListModel> Handle(GetListCoffeQuary request, CancellationToken cancellationToken)
            {
                IPaginate<Coffe> coffes = await _coffeRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                CoffeListModel mappedCoffeListModel = _mapper.Map<CoffeListModel>(coffes);

                return mappedCoffeListModel;
                

            }
        }
    }
}
