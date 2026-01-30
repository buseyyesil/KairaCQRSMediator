using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands
{
    public class RemovePhotoGalleryCommand : IRequest
    {
        public int Id { get; set; }

        public RemovePhotoGalleryCommand(int id)
        {
            Id = id;
        }
    }
}
