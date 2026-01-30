namespace KairaCQRSMediator.DataAccess.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string Platform { get; set; } 
        public string Url { get; set; }
        public string Icon { get; set; } 
        public int DisplayOrder { get; set; }
    }
}
