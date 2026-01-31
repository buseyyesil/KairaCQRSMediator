namespace KairaCQRSMediator.Features.Mediator.Results.CollectionResults
{
    public class GetCollectionByIdQueryResult
    {
        public int CollectionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
