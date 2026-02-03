using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands;
using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.RelatedProductHandlers
{
    public class CreateRelatedProductCommandHandler : IRequestHandler<CreateRelatedProductCommand>
    {
        private readonly IRepository<RelatedProduct> _repository;
        private readonly IMapper _mapper;

        public CreateRelatedProductCommandHandler(IRepository<RelatedProduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateRelatedProductCommand request, CancellationToken cancellationToken)
        {
            var relatedProduct = _mapper.Map<RelatedProduct>(request);
            await _repository.CreateAsync(relatedProduct);
        }
    }
}