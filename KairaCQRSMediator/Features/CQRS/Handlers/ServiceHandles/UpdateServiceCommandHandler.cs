using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.ServiceCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommand command)
        {
            var service = new Service
            {
                ServiceId = command.ServiceId,
                Title = command.Title,
                Description = command.Description,
                Icon = command.Icon,
                VideoUrl = command.VideoUrl
            };
            await _repository.UpdateAsync(service);
        }
    }
}