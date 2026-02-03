using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Command.NewarrivalproductCommands
{
    public class UpdateNewarrivalproductCommand:IRequest
    {
        public int NewArrivalProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
