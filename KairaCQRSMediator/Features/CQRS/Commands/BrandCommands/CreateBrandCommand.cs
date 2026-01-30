namespace KairaCQRSMediator.Features.CQRS.Commands.BrandCommands
{
    public class CreateBrandCommand
    {
        public string BrandName { get; set; }
        public string LogoUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
