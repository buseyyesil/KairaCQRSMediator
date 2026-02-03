using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.RelatedProductHandlers
{
    public class RemoveRelatedProductCommandHandler : IRequestHandler<RemoveRelatedProductCommand>
    {
        private readonly IRepository<RelatedProduct> _repository;

        public RemoveRelatedProductCommandHandler(IRepository<RelatedProduct> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveRelatedProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}