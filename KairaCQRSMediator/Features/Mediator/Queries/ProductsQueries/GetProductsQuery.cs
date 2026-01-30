using KairaCQRSMediator.Features.Mediator.Results.ProductResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.ProductsQueries
{
    public class GetProductsQuery:IRequest<List<GetProductsQueryResult>>
    {

    }
}
