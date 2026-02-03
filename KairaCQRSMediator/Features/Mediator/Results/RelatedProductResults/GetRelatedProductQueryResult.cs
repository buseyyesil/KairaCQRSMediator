namespace KairaCQRSMediator.Features.Mediator.Results.RelatedProductResults
{
    public class GetRelatedProductQueryResult
    {
        public int RelatedProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}