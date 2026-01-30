using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.ProductsQueries;
using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ProductHandlers
{
    public class GetProductsByIdQueryHandler(IRepository<Product> _repository, IMapper _mapper) : IRequestHandler<GetProductsByIdQuery, GetProductsByIdQueryResult>
    {
        public async Task<GetProductsByIdQueryResult> Handle(GetProductsByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetProductsByIdQueryResult>(product);
        }
    }
}
