using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands
{
    public class RemoveRelatedProductCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveRelatedProductCommand(int id)
        {
            Id = id;
        }
    }
}