using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.SocialMediaCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly KairaContext _context;

        public CreateSocialMediaCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            _context.SocialMedias.Add(new SocialMedia
            {
                Platform = request.Platform,
                Url = request.Url,
                Icon = request.Icon
            });
            await _context.SaveChangesAsync();
        }
    }
}