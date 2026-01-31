using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;

using KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.CollectionHandlers
{
    public class CreateCollectionCommandHandler : IRequestHandler<CreateCollectionCommand>
    {
        private readonly IRepository<Collection> _repository;
        private readonly IMapper _mapper;

        public CreateCollectionCommandHandler(IRepository<Collection> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = _mapper.Map<Collection>(request);
            await _repository.CreateAsync(collection);
        }
    }
}