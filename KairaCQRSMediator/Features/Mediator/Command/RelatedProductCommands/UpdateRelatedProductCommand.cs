using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands
{
    public class UpdateRelatedProductCommand : IRequest
    {
        public int RelatedProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}