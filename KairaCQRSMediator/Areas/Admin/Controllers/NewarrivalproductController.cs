using KairaCQRSMediator.Features.Mediator.Command.NewarrivalproductCommands;
using KairaCQRSMediator.Features.Mediator.Commands.NewarrivalproductCommands;

using KairaCQRSMediator.Features.Mediator.Queries.NewarrivalproductQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewArrivalProductController : Controller
    {
        private readonly IMediator _mediator;

        public NewArrivalProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _mediator.Send(new GetNewarrivalproductQuery());
            return View(products);
        }

        public IActionResult CreateNewArrivalProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewArrivalProduct(CreateNewarrivalproductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            TempData["Success"] = "Ürün başarıyla eklendi!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateNewArrivalProduct(int id)
        {
            var product = await _mediator.Send(new GetNewarrivalproductByIdQuery(id));
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateNewArrivalProduct(UpdateNewarrivalproductCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            TempData["Success"] = "Ürün başarıyla güncellendi!";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteNewArrivalProduct(int id)
        {
            await _mediator.Send(new RemoveNewarrivalproductCommand(id));
            TempData["Success"] = "Ürün başarıyla silindi!";
            return RedirectToAction("Index");
        }
    }
}