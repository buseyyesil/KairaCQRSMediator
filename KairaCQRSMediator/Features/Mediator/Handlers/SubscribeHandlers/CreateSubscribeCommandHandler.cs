using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.SubscribeCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.SubscribeHandlers
{
    public class CreateSubscribeCommandHandler : IRequestHandler<CreateSubscribeCommand>
    {
        private readonly KairaContext _context;

        public CreateSubscribeCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateSubscribeCommand request, CancellationToken cancellationToken)
        {
            _context.Subscribes.Add(new Subscribe
            {
                Email = request.Email,
                SubscribeDate = request.SubscribeDate,
                IsActive = request.IsActive
            });
            await _context.SaveChangesAsync();
        }
    }
}