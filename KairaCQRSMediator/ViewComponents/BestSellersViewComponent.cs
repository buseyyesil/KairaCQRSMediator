using KairaCQRSMediator.Features.Mediator.Queries.ProductsQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class BestSellersViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public BestSellersViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var products = await _mediator.Send(new GetProductsQuery());

            var bestSellers = products.Take(6).ToList();

            return View(bestSellers);
        }
    }
}