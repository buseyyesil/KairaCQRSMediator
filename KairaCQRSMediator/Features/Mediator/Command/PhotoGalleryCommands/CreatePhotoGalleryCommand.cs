using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands
{
    public class CreatePhotoGalleryCommand : IRequest
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? AltText { get; set; }
        public int DisplayOrder { get; set; }
    }
}
