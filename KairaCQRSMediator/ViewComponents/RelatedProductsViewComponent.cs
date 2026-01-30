using KairaCQRSMediator.Features.Mediator.Queries.ProductsQueries;
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

        public async Task<IViewComponentResult> InvokeAsync(int count = 10)
        {
            var products = await _mediator.Send(new GetProductsQuery());
            // Random ürünler göster veya önerilen ürünleri al
            var relatedProducts = products.Take(count).ToList();
            return View(relatedProducts);
        }
    }
}