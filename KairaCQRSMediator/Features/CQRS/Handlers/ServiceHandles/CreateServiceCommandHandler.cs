using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.ServiceCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly IRepository<Service> _repository;

        public CreateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateServiceCommand command)
        {
            var service = new Service
            {
                Title = command.Title,
                Description = command.Description,
                Icon = command.Icon,
                VideoUrl = command.VideoUrl
            };
            await _repository.CreateAsync(service);
        }
    }
}