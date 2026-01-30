using KairaCQRSMediator.Features.Mediator.Results.PhotoGalleryResults;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Queries.PhotoGalleryQueries
{
    public class GetPhotoGalleryByIdQuery : IRequest<GetPhotoGalleryByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPhotoGalleryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
