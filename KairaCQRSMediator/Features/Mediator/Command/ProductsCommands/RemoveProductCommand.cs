using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Command.ProductsCommands
{
    public class RemoveProductCommand(int id):IRequest
    {
        public int Id { get; set; } = id;
    }
}
