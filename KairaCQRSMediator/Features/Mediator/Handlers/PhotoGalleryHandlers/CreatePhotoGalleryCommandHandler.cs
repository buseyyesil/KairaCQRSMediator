using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.PhotoGalleryHandlers
{
    public class CreatePhotoGalleryCommandHandler : IRequestHandler<CreatePhotoGalleryCommand>
    {
        private readonly KairaContext _context;

        public CreatePhotoGalleryCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(CreatePhotoGalleryCommand request, CancellationToken cancellationToken)
        {
            _context.PhotoGalleries.Add(new PhotoGallery
            {
                ImageUrl = request.ImageUrl,
                Title = request.Title ?? "",
                AltText = request.AltText ?? "",
                DisplayOrder = request.DisplayOrder
            });
            await _context.SaveChangesAsync();
        }
    }
}