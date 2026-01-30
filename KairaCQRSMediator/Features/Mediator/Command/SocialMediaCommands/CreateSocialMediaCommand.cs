using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.SocialMediaCommands
{
    public class CreateSocialMediaCommand : IRequest
    {
        public string Platform { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}