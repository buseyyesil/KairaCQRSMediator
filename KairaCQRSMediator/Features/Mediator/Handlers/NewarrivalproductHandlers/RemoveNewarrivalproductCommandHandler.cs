using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.NewarrivalproductCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.NewArrivalProductHandlers
{
    public class RemoveNewArrivalProductCommandHandler : IRequestHandler<RemoveNewarrivalproductCommand>
    {
        private readonly IRepository<Newarrivalproduct> _repository;

        public RemoveNewArrivalProductCommandHandler(IRepository<Newarrivalproduct> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveNewarrivalproductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}