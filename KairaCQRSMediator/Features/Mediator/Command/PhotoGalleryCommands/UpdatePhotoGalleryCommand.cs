using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands
{
    public class UpdatePhotoGalleryCommand : IRequest
    {
        public int PhotoGalleryId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? AltText { get; set; }
        public int DisplayOrder { get; set; }
    }
}
