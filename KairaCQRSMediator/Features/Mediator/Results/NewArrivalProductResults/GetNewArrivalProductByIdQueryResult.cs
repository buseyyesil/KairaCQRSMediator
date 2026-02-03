namespace KairaCQRSMediator.Features.Mediator.Results.NewarrivalproductResults
{
    public class GetNewarrivalproductByIdQueryResult
    {
        public int NewArrivalProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}