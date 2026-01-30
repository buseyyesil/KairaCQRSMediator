namespace KairaCQRSMediator.Features.Mediator.Results.ContactInfoResults
{
    public class GetContactInfoQueryResult
    {
        public int ContactInfoId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WorkingHours { get; set; }
    }
}