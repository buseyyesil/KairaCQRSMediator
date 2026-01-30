using KairaCQRSMediator.Features.CQRS.Commands.ServiceCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.ServiceHandlers;
using KairaCQRSMediator.Features.CQRS.Queries.ServiceQueries;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly GetServiceQueryHandler _getServiceQueryHandler;
        private readonly GetServiceByIdQueryHandler _getServiceByIdQueryHandler;
        private readonly CreateServiceCommandHandler _createServiceCommandHandler;
        private readonly UpdateServiceCommandHandler _updateServiceCommandHandler;
        private readonly RemoveServiceCommandHandler _removeServiceCommandHandler;

        public ServiceController(GetServiceQueryHandler getServiceQueryHandler, GetServiceByIdQueryHandler getServiceByIdQueryHandler, CreateServiceCommandHandler createServiceCommandHandler, UpdateServiceCommandHandler updateServiceCommandHandler, RemoveServiceCommandHandler removeServiceCommandHandler)
        {
            _getServiceQueryHandler = getServiceQueryHandler;
            _getServiceByIdQueryHandler = getServiceByIdQueryHandler;
            _createServiceCommandHandler = createServiceCommandHandler;
            _updateServiceCommandHandler = updateServiceCommandHandler;
            _removeServiceCommandHandler = removeServiceCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var services = await _getServiceQueryHandler.Handle();
            return View(services);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateServiceCommand command)
        {
            if (ModelState.IsValid)
            {
                await _createServiceCommandHandler.Handle(command);
                TempData["Success"] = "Hizmet başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Update(int id)
        {
            var service = await _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            var command = new UpdateServiceCommand { ServiceId = service.ServiceId, Title = service.Title, Description = service.Description, Icon = service.Icon, VideoUrl = service.VideoUrl };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceCommand command)
        {
            if (ModelState.IsValid)
            {
                await _updateServiceCommandHandler.Handle(command);
                TempData["Success"] = "Hizmet başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var service = await _getServiceByIdQueryHandler.Handle(new GetServiceByIdQuery(id));
            return View(service);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _removeServiceCommandHandler.Handle(new RemoveServiceCommand(id));
            TempData["Success"] = "Hizmet başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }
    }
}