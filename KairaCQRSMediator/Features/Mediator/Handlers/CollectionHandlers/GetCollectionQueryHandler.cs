using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.CollectionQueries;
using KairaCQRSMediator.Features.Mediator.Results.CollectionResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.CollectionHandlers
{
    public class GetCollectionQueryHandler : IRequestHandler<GetCollectionQuery, List<GetCollectionQueryResult>>
    {
        private readonly IRepository<Collection> _repository;
        private readonly IMapper _mapper;

        public GetCollectionQueryHandler(IRepository<Collection> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCollectionQueryResult>> Handle(GetCollectionQuery request, CancellationToken cancellationToken)
        {
            var collections = await _repository.GetAllAsync();
            return _mapper.Map<List<GetCollectionQueryResult>>(collections);
        }
    }
}