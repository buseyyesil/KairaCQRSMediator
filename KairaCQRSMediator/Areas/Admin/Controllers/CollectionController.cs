using KairaCQRSMediator.Features.Mediator.Commands.CollectionCommands;
using KairaCQRSMediator.Features.Mediator.Queries.CollectionQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CollectionController : Controller
    {
        private readonly IMediator _mediator;

        public CollectionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var collections = await _mediator.Send(new GetCollectionQuery());
            return View(collections);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateCollectionCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "Koleksiyon başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Update(int id)
        {
            var collection = await _mediator.Send(new GetCollectionByIdQuery(id));
            var command = new UpdateCollectionCommand
            {
                CollectionId = collection.CollectionId,
                Title = collection.Title,
                Description = collection.Description,
                ImageUrl = collection.ImageUrl
            };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCollectionCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "Koleksiyon başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var collection = await _mediator.Send(new GetCollectionByIdQuery(id));
            return View(collection);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new RemoveCollectionCommand(id));
            TempData["Success"] = "Koleksiyon başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }
    }
}