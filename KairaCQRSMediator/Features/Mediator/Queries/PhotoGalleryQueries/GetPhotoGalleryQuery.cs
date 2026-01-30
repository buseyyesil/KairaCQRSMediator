using KairaCQRSMediator.Features.Mediator.Results.PhotoGalleryResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.PhotoGalleryQueries
{
    public class GetPhotoGalleryQuery : IRequest<List<GetPhotoGalleryQueryResult>>
    {
    }
}