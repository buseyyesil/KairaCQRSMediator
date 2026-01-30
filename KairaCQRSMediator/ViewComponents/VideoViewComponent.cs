using KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class VideoViewComponent : ViewComponent
    {
        private readonly GetServiceQueryHandler _getServiceQueryHandler;

        public VideoViewComponent(GetServiceQueryHandler getServiceQueryHandler)
        {
            _getServiceQueryHandler = getServiceQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var services = await _getServiceQueryHandler.Handle();

            var videoService = services.FirstOrDefault(x => !string.IsNullOrEmpty(x.VideoUrl));
            return View(videoService);
        }
    }
}