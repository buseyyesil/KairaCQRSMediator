using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands
{
    public class UpdateCollectionCommand:IRequest
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }   
        public string Description { get; set; }
        public string ImageUrl { get; set; }    
    }
}
