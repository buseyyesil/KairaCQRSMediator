using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Results.ServiceResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler
    {
        private readonly IRepository<Service> _serviceRepository;

        public GetServiceQueryHandler(IRepository<Service> serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<GetServiceQueryResult>> Handle()
        {
            var services = await _serviceRepository.GetAllAsync();
            return services.Select(service => new GetServiceQueryResult
            {
                ServiceId = service.ServiceId,
                Title = service.Title,
                Description = service.Description,
                Icon = service.Icon,
                VideoUrl = service.VideoUrl
            }).ToList();
        }
    }
}