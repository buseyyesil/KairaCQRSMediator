using KairaCQRSMediator.DataAccess.Context;

using KairaCQRSMediator.Features.Mediator.Commands.SocialMediaCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class RemoveSocialMediaCommandHandler : IRequestHandler<RemoveSocialMediaCommand>
    {
        private readonly KairaContext _context;

        public RemoveSocialMediaCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.SocialMedias.FindAsync(request.Id);
            _context.SocialMedias.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}