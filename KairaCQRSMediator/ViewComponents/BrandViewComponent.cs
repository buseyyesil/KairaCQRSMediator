using KairaCQRSMediator.Features.CQRS.Handlers.BrandHandlers;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class BrandViewComponent : ViewComponent
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;

        public BrandViewComponent(GetBrandQueryHandler getBrandQueryHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = await _getBrandQueryHandler.Handle();
            return View(brands);
        }
    }
}