using KairaCQRSMediator.Features.Mediator.Commands.ContactInfoCommands;
using KairaCQRSMediator.Features.Mediator.Queries.ContactInfoQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactInfoController : Controller
    {
        private readonly IMediator _mediator;

        public ContactInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var contactInfo = await _mediator.Send(new GetContactInfoQuery());
                return View(contactInfo);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "İletişim bilgileri yüklenirken hata oluştu.";
                return View();
            }
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactInfoCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "İletişim bilgileri eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Update()
        {
            var contactInfo = await _mediator.Send(new GetContactInfoQuery());

            if (contactInfo == null || contactInfo.ContactInfoId == 0)
            {
                TempData["Error"] = "İletişim bilgisi bulunamadı!";
                return RedirectToAction(nameof(Index));
            }

            var command = new UpdateContactInfoCommand
            {
                ContactInfoId = contactInfo.ContactInfoId,
                Phone = contactInfo.Phone,
                Email = contactInfo.Email,
                Address = contactInfo.Address,
                WorkingHours = contactInfo.WorkingHours
            };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateContactInfoCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "İletişim bilgileri güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
    }
}