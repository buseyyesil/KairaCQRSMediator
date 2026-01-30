namespace KairaCQRSMediator.DataAccess.Entities
{
    public class Subscribe
    {
        public int SubscribeId { get; set; }
        public string Email { get; set; }
        public DateTime SubscribeDate { get; set; }
        public bool IsActive { get; set; }
    }
}