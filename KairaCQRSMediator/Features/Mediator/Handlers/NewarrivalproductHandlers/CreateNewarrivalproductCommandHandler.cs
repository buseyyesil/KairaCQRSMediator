using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Command.NewarrivalproductCommands;

using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.NewArrivalProductHandlers
{
    public class CreateNewArrivalProductCommandHandler : IRequestHandler<CreateNewarrivalproductCommand>
    {
        private readonly IRepository<Newarrivalproduct> _repository;
        private readonly IMapper _mapper;

        public CreateNewArrivalProductCommandHandler(IRepository<Newarrivalproduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateNewarrivalproductCommand request, CancellationToken cancellationToken)
        {
            var newArrivalProduct = _mapper.Map<Newarrivalproduct>(request);
            await _repository.CreateAsync(newArrivalProduct);
        }
    }
}