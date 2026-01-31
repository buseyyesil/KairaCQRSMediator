using KairaCQRSMediator.Features.Mediator.Results.CollectionResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.CollectionQueries
{
    public class GetCollectionQuery : IRequest<List<GetCollectionQueryResult>>
    {
    }
}