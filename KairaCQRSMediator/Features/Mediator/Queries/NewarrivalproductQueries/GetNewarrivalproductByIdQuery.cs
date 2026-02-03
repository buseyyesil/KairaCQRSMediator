using KairaCQRSMediator.Features.Mediator.Results.NewarrivalproductResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.NewarrivalproductQueries
{
    public class GetNewarrivalproductByIdQuery : IRequest<GetNewarrivalproductByIdQueryResult>
    {
        public int Id { get; set; }

        public GetNewarrivalproductByIdQuery(int id)
        {
            Id = id;
        }
    }
}