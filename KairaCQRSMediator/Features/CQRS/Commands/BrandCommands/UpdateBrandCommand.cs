namespace KairaCQRSMediator.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
