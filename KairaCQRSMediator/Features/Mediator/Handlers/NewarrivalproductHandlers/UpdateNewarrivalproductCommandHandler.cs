using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Command.NewarrivalproductCommands;
using KairaCQRSMediator.Features.Mediator.Commands.NewarrivalproductCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.NewArrivalProductHandlers
{
    public class UpdateNewArrivalProductCommandHandler : IRequestHandler<UpdateNewarrivalproductCommand>
    {
        private readonly IRepository<Newarrivalproduct> _repository;
        private readonly IMapper _mapper;

        public UpdateNewArrivalProductCommandHandler(IRepository<Newarrivalproduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateNewarrivalproductCommand request, CancellationToken cancellationToken)
        {
            var newArrivalProduct = _mapper.Map<Newarrivalproduct>(request);
            await _repository.UpdateAsync(newArrivalProduct);
        }
    }
}