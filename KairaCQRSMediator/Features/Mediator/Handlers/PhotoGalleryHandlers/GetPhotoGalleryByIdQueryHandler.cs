using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Queries.PhotoGalleryQueries;
using KairaCQRSMediator.Features.Mediator.Results.PhotoGalleryResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.PhotoGalleryHandlers
{
    public class GetPhotoGalleryByIdQueryHandler : IRequestHandler<GetPhotoGalleryByIdQuery, GetPhotoGalleryByIdQueryResult>
    {
        private readonly KairaContext _context;

        public GetPhotoGalleryByIdQueryHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task<GetPhotoGalleryByIdQueryResult> Handle(GetPhotoGalleryByIdQuery request, CancellationToken cancellationToken)
        {
            var photo = await _context.PhotoGalleries.FindAsync(request.Id);
            return new GetPhotoGalleryByIdQueryResult
            {
                PhotoGalleryId = photo.PhotoGalleryId,
                ImageUrl = photo.ImageUrl,
                Title = photo.Title,
                AltText = photo.AltText,
                DisplayOrder = photo.DisplayOrder
            };
        }
    }
}