using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.RelatedProductQueries;
using KairaCQRSMediator.Features.Mediator.Results.RelatedProductResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.RelatedProductHandlers
{
    public class GetRelatedProductByIdQueryHandler : IRequestHandler<GetRelatedProductByIdQuery, GetRelatedProductByIdQueryResult>
    {
        private readonly IRepository<RelatedProduct> _repository;
        private readonly IMapper _mapper;

        public GetRelatedProductByIdQueryHandler(IRepository<RelatedProduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetRelatedProductByIdQueryResult> Handle(GetRelatedProductByIdQuery request, CancellationToken cancellationToken)
        {
            var relatedProduct = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetRelatedProductByIdQueryResult>(relatedProduct);
        }
    }
}