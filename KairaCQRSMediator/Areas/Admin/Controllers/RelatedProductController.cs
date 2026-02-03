using KairaCQRSMediator.Features.Mediator.Commands.RelatedProductCommands;
using KairaCQRSMediator.Features.Mediator.Queries.RelatedProductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RelatedProductController : Controller
    {
        private readonly IMediator _mediator;

        public RelatedProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetRelatedProductQuery());
            return View(products);
        }

        public IActionResult CreateRelatedProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRelatedProduct(CreateRelatedProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            TempData["Success"] = "Ürün başarıyla eklendi!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateRelatedProduct(int id)
        {
            var product = await _mediator.Send(new GetRelatedProductByIdQuery(id));
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRelatedProduct(UpdateRelatedProductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            TempData["Success"] = "Ürün başarıyla güncellendi!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRelatedProduct(int id)
        {
            await _mediator.Send(new RemoveRelatedProductCommand(id));
            TempData["Success"] = "Ürün başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }
}