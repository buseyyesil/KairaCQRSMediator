using KairaCQRSMediator.Features.Mediator.Commands.PhotoGalleryCommands;
using KairaCQRSMediator.Features.Mediator.Queries.PhotoGalleryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PhotoGalleryController : Controller
    {
        private readonly IMediator _mediator;

        public PhotoGalleryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var photos = await _mediator.Send(new GetPhotoGalleryQuery());
            return View(photos);
        }

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreatePhotoGalleryCommand command)
        {
           
            command.Title = command.Title ?? "Photo";
            command.AltText = command.AltText ?? "Instagram";
            command.DisplayOrder = command.DisplayOrder == 0 ? 1 : command.DisplayOrder;

            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var photo = await _mediator.Send(new GetPhotoGalleryByIdQuery(id));
            var command = new UpdatePhotoGalleryCommand { PhotoGalleryId = photo.PhotoGalleryId, ImageUrl = photo.ImageUrl, Title = photo.Title, AltText = photo.AltText, DisplayOrder = photo.DisplayOrder };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePhotoGalleryCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "Fotoğraf başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var photo = await _mediator.Send(new GetPhotoGalleryByIdQuery(id));
            return View(photo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new RemovePhotoGalleryCommand(id));
            TempData["Success"] = "Fotoğraf başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }
    }
}