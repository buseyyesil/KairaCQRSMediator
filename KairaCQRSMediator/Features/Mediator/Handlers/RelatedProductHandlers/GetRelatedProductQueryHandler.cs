using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.RelatedProductQueries;
using KairaCQRSMediator.Features.Mediator.Results.RelatedProductResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.RelatedProductHandlers
{
    public class GetRelatedProductQueryHandler : IRequestHandler<GetRelatedProductQuery, List<GetRelatedProductQueryResult>>
    {
        private readonly IRepository<RelatedProduct> _repository;
        private readonly IMapper _mapper;

        public GetRelatedProductQueryHandler(IRepository<RelatedProduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetRelatedProductQueryResult>> Handle(GetRelatedProductQuery request, CancellationToken cancellationToken)
        {
            var relatedProducts = await _repository.GetAllAsync();
            return _mapper.Map<List<GetRelatedProductQueryResult>>(relatedProducts);
        }
    }
}