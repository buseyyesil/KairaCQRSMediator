using KairaCQRSMediator.Features.Mediator.Queries.NewarrivalproductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class NewArrivalViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public NewArrivalViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _mediator.Send(new GetNewarrivalproductQuery());
            return View(products);
        }
    }
}