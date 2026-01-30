using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.SubscribeCommands
{
    public class CreateSubscribeCommand : IRequest
    {
        public string Email { get; set; }
        public DateTime SubscribeDate { get; set; }
        public bool IsActive { get; set; }
    }
}