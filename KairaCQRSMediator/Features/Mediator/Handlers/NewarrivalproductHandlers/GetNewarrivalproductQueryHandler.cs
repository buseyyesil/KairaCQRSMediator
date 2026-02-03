using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.NewarrivalproductQueries;
using KairaCQRSMediator.Features.Mediator.Results.NewarrivalproductResults;

using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.NewArrivalProductHandlers
{
    public class GetNewarrivalproductQueryHandler : IRequestHandler<GetNewarrivalproductQuery, List<GetNewarrivalproductQueryResult>>
    {
        private readonly IRepository<Newarrivalproduct> _repository;
        private readonly IMapper _mapper;

        public GetNewarrivalproductQueryHandler(IRepository<Newarrivalproduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetNewarrivalproductQueryResult>> Handle(GetNewarrivalproductQuery request, CancellationToken cancellationToken)
        {
            var newArrivalProducts = await _repository.GetAllAsync();
            return _mapper.Map<List<GetNewarrivalproductQueryResult>>(newArrivalProducts);
        }
    }
}