using KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class FeaturesViewComponent : ViewComponent
    {
        private readonly GetServiceQueryHandler _getServiceQueryHandler;

        public FeaturesViewComponent(GetServiceQueryHandler getServiceQueryHandler)
        {
            _getServiceQueryHandler = getServiceQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _getServiceQueryHandler.Handle();
            return View(services);
        }
    }
}