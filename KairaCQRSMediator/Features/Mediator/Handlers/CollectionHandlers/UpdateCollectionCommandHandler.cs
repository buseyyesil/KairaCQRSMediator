using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;

using KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.CollectionHandlers
{
    public class UpdateCollectionCommandHandler : IRequestHandler<UpdateCollectionCommand>
    {
        private readonly IRepository<Collection> _repository;
        private readonly IMapper _mapper;

        public UpdateCollectionCommandHandler(IRepository<Collection> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = _mapper.Map<Collection>(request);
            await _repository.UpdateAsync(collection);
        }
    }
}