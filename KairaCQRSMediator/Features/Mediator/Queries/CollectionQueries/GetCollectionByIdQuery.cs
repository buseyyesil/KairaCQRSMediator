using KairaCQRSMediator.Features.Mediator.Results.CollectionResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.CollectionQueries
{
    public class GetCollectionByIdQuery : IRequest<GetCollectionByIdQueryResult>
    {
        public int Id { get; set; }

        public GetCollectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}