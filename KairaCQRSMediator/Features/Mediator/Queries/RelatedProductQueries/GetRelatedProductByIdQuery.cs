using KairaCQRSMediator.Features.Mediator.Results.RelatedProductResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.RelatedProductQueries
{
    public class GetRelatedProductByIdQuery : IRequest<GetRelatedProductByIdQueryResult>
    {
        public int Id { get; set; }

        public GetRelatedProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}