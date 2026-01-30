using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.BrandCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var brand = new Brand
            {
                BrandId = command.BrandId,
                BrandName = command.BrandName,
                LogoUrl = command.LogoUrl,
                DisplayOrder = command.DisplayOrder
            };
            await _repository.UpdateAsync(brand);
        }
    }
}
