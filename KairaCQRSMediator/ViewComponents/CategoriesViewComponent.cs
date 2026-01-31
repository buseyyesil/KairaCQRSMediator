using KairaCQRSMediator.Features.Mediator.Queries.CollectionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class CollectionViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public CollectionViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var collections = await _mediator.Send(new GetCollectionQuery());
            var collection = collections.FirstOrDefault();
            return View(collection);
        }
    }
}