using KairaCQRSMediator.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int id)
        {
            Id = id;
        }
    }
}