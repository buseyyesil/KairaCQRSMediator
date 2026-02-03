using AutoMapper;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Queries.NewarrivalproductQueries;
using KairaCQRSMediator.Features.Mediator.Results.NewarrivalproductResults;

using KairaCQRSMediator.Repositories;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.NewArrivalProductHandlers
{
    public class GetNewarrivalproductByIdQueryHandler : IRequestHandler<GetNewarrivalproductByIdQuery, GetNewarrivalproductByIdQueryResult>
    {
        private readonly IRepository<Newarrivalproduct> _repository;
        private readonly IMapper _mapper;

        public GetNewarrivalproductByIdQueryHandler(IRepository<Newarrivalproduct> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetNewarrivalproductByIdQueryResult> Handle(GetNewarrivalproductByIdQuery request, CancellationToken cancellationToken)
        {
            var newArrivalProduct = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetNewarrivalproductByIdQueryResult>(newArrivalProduct);
        }
    }
}