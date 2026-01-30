namespace KairaCQRSMediator.Features.CQRS.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public int ServiceId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string? VideoUrl { get; set; }
    }
}