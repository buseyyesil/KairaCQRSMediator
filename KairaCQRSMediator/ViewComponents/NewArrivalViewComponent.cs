using KairaCQRSMediator.Features.Mediator.Queries.ProductsQueries;
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

        public async Task<IViewComponentResult> InvokeAsync(int count = 10)
        {
            var products = await _mediator.Send(new GetProductsQuery());
          
            var newProducts = products.OrderByDescending(x => x.ProductId).Take(count).ToList();
            return View(newProducts);
        }
    }
}