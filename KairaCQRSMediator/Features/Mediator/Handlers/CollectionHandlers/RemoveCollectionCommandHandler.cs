using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.CollectionHandlers
{
    public class RemoveCollectionCommandHandler : IRequestHandler<RemoveCollectionCommand>
    {
        private readonly IRepository<Collection> _repository;

        public RemoveCollectionCommandHandler(IRepository<Collection> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCollectionCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}