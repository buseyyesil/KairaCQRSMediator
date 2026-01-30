using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.SubscribeQueries;
using KairaCQRSMediator.Features.Mediator.Results.SubscribeResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.SubscribeHandlers
{
    public class GetSubscribeQueryHandler : IRequestHandler<GetSubscribeQuery, List<GetSubscribeQueryResult>>
    {
        private readonly IRepository<Subscribe> _repository;
        private readonly IMapper _mapper;

        public GetSubscribeQueryHandler(IRepository<Subscribe> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSubscribeQueryResult>> Handle(GetSubscribeQuery request, CancellationToken cancellationToken)
        {
            var subscribes = await _repository.GetAllAsync();
            return _mapper.Map<List<GetSubscribeQueryResult>>(subscribes);
        }
    }
}
