using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Queries.ServiceQueries;
using KairaCQRSMediator.Features.CQRS.Results.ServiceResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery query)
        {
            var service = await _repository.GetByIdAsync(query.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceId = service.ServiceId,
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon,
                VideoUrl = service.VideoUrl
            };
        }
    }
}