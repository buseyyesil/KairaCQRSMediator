namespace KairaCQRSMediator.Features.CQRS.Results.BrandResults
{
    public class GetBrandQueryResult
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
