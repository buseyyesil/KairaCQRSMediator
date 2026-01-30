using KairaCQRSMediator.Features.Mediator.Results.ContactInfoResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.ContactInfoQueries
{
    public class GetContactInfoQuery : IRequest<GetContactInfoQueryResult>
    {
    }
}