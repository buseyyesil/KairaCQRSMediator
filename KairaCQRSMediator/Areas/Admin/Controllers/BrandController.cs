using KairaCQRSMediator.Features.CQRS.Commands.BrandCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.BrandHandlers;
using KairaCQRSMediator.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly RemoveBrandCommandHandler _removeBrandCommandHandler;

        public BrandController(GetBrandQueryHandler getBrandQueryHandler, GetBrandByIdQueryHandler getBrandByIdQueryHandler, CreateBrandCommandHandler createBrandCommandHandler, UpdateBrandCommandHandler updateBrandCommandHandler, RemoveBrandCommandHandler removeBrandCommandHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _removeBrandCommandHandler = removeBrandCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _getBrandQueryHandler.Handle();
            return View(brands);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand command)
        {
            if (ModelState.IsValid)
            {
                await _createBrandCommandHandler.Handle(command);
                TempData["Success"] = "Marka başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Update(int id)
        {
            var brand = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            var command = new UpdateBrandCommand { BrandId = brand.BrandId, BrandName = brand.BrandName, LogoUrl = brand.LogoUrl, DisplayOrder = brand.DisplayOrder };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBrandCommand command)
        {
            if (ModelState.IsValid)
            {
                await _updateBrandCommandHandler.Handle(command);
                TempData["Success"] = "Marka başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return View(brand);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _removeBrandCommandHandler.Handle(new RemoveBrandCommand(id));
            TempData["Success"] = "Marka başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }
    }
}