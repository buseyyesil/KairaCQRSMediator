using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Queries.PhotoGalleryQueries;
using KairaCQRSMediator.Features.Mediator.Results.PhotoGalleryResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KairaCQRSMediator.Features.Mediator.Handlers.PhotoGalleryHandlers
{
    public class GetPhotoGalleryQueryHandler : IRequestHandler<GetPhotoGalleryQuery, List<GetPhotoGalleryQueryResult>>
    {
        private readonly KairaContext _context;

        public GetPhotoGalleryQueryHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task<List<GetPhotoGalleryQueryResult>> Handle(GetPhotoGalleryQuery request, CancellationToken cancellationToken)
        {
            var photos = await _context.PhotoGalleries.OrderBy(x => x.DisplayOrder).ToListAsync();
            return photos.Select(x => new GetPhotoGalleryQueryResult
            {
                PhotoGalleryId = x.PhotoGalleryId,
                ImageUrl = x.ImageUrl,
                Title = x.Title,
                AltText = x.AltText,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }
    }
}