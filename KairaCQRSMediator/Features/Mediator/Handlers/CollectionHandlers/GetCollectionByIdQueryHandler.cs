using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.CollectionQueries;
using KairaCQRSMediator.Features.Mediator.Results.CollectionResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.CollectionHandlers
{
    public class GetCollectionByIdQueryHandler : IRequestHandler<GetCollectionByIdQuery, GetCollectionByIdQueryResult>
    {
        private readonly IRepository<Collection> _repository;
        private readonly IMapper _mapper;

        public GetCollectionByIdQueryHandler(IRepository<Collection> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCollectionByIdQueryResult> Handle(GetCollectionByIdQuery request, CancellationToken cancellationToken)
        {
            var collection = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetCollectionByIdQueryResult>(collection);
        }
    }
}