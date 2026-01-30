using KairaCQRSMediator.Features.Mediator.Queries.PhotoGalleryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class InstagramViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public InstagramViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var photos = await _mediator.Send(new GetPhotoGalleryQuery());
            var instagramPhotos = photos.Take(6).ToList();
            return View(instagramPhotos);
        }
    }
}