using KairaCQRSMediator.Features.Mediator.Results.RelatedProductResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.RelatedProductQueries
{
    public class GetRelatedProductQuery : IRequest<List<GetRelatedProductQueryResult>>
    {
    }
}