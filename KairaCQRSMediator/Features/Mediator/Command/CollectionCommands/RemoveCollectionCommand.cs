using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands
{
    public class RemoveCollectionCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveCollectionCommand(int id)
        {
            Id = id;
        }
    }
}