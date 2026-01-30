namespace KairaCQRSMediator.Features.CQRS.Results.TestimonialResults
{
    public class GetTestimonialQueryResult
    {
        public int TestimonialId { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string? ImageUrl { get; set; }
    }
}