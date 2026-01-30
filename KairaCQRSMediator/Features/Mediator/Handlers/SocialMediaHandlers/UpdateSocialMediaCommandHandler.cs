using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Commands.SocialMediaCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly KairaContext _context;

        public UpdateSocialMediaCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.SocialMedias.FindAsync(request.SocialMediaId);
            value.Platform = request.Platform;
            value.Url = request.Url;
            value.Icon = request.Icon;
            await _context.SaveChangesAsync();
        }
    }
}