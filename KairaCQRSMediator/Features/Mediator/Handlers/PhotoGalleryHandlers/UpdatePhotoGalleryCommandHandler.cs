using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.PhotoGalleryHandlers
{
    public class UpdatePhotoGalleryCommandHandler : IRequestHandler<UpdatePhotoGalleryCommand>
    {
        private readonly KairaContext _context;

        public UpdatePhotoGalleryCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdatePhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            var photo = await _context.PhotoGalleries.FindAsync(request.PhotoGalleryId);
            photo.ImageUrl = request.ImageUrl;
            photo.Title = request.Title ?? "";
            photo.AltText = request.AltText ?? "";
            photo.DisplayOrder = request.DisplayOrder;
            await _context.SaveChangesAsync();
        }
    }
}