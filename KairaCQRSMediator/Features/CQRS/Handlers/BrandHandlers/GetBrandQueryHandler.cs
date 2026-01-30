using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Results.BrandResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var brands = await _repository.GetAllAsync();
            return brands.OrderBy(x => x.DisplayOrder).Select(x => new GetBrandQueryResult
            {
                BrandId = x.BrandId,
                BrandName = x.BrandName,
                LogoUrl = x.LogoUrl,
                DisplayOrder = x.DisplayOrder
            }).ToList();
        }
    }
}