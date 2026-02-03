using KairaCQRSMediator.Features.Mediator.Results.NewarrivalproductResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.NewarrivalproductQueries
{
    public class GetNewarrivalproductQuery : IRequest<List<GetNewarrivalproductQueryResult>>
    {
    }
}