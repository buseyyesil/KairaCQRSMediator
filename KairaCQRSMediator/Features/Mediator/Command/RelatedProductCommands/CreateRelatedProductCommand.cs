using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands
{
    public class CreateRelatedProductCommand : IRequest
    {
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}