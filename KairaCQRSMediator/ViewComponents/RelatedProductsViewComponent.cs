using KairaCQRSMediator.Features.Mediator.Queries.RelatedProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class RelatedProductsViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public RelatedProductsViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _mediator.Send(new GetRelatedProductQuery());
            return View(products);
        }
    }
}