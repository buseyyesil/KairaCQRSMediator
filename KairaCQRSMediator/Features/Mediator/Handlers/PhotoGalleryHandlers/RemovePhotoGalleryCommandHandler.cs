using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.PhotoGalleryHandlers
{
    public class RemovePhotoGalleryCommandHandler : IRequestHandler<RemovePhotoGalleryCommand>
    {
        private readonly KairaContext _context;

        public RemovePhotoGalleryCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(RemovePhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            var photo = await _context.PhotoGalleries.FindAsync(request.Id);
            _context.PhotoGalleries.Remove(photo);
            await _context.SaveChangesAsync();
        }
    }
}