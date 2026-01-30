namespace KairaCQRSMediator.Features.CQRS.Commands.TestimonialCommands
{
    public class UpdateTestimonialCommand
    {
        public int TestimonialId { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string? ImageUrl { get; set; }
    }
}