using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Command.NewarrivalproductCommands
{
    public class CreateNewarrivalproductCommand:IRequest
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
