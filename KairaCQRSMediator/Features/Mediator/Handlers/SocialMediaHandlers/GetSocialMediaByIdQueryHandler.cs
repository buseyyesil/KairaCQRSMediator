using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Queries.SocialMediaQueries;
using KairaCQRSMediator.Features.Mediator.Results.SocialMediaResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly KairaContext _context;

        public GetSocialMediaByIdQueryHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.SocialMedias.FindAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = value.SocialMediaId,
                Platform = value.Platform,
                Url = value.Url,
                Icon = value.Icon
            };
        }
    }
}