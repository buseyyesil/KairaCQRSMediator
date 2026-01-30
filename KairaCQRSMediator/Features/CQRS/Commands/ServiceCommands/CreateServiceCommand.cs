namespace KairaCQRSMediator.Features.CQRS.Commands.ServiceCommands
{
    public class CreateServiceCommand
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public string? VideoUrl { get; set; }
    }
}