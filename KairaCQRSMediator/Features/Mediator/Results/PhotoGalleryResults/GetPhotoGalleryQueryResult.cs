namespace KairaCQRSMediator.Features.Mediator.Results.PhotoGalleryResults
{
    public class GetPhotoGalleryQueryResult
    {
        public int PhotoGalleryId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? AltText { get; set; }
        public int DisplayOrder { get; set; }
    }
}