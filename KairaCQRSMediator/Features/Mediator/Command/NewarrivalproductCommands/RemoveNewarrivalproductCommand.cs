using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.NewarrivalproductCommands
{
    public class RemoveNewarrivalproductCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveNewarrivalproductCommand(int id)
        {
            Id = id;
        }
    }
}