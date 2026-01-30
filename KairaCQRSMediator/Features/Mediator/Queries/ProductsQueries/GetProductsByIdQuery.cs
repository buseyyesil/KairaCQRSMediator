using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.ProductsQueries
{
    public class GetProductsByIdQuery(int id) : IRequest<GetProductsByIdQueryResult>
    {
        public int Id { get; set; } = id;


    }
}
