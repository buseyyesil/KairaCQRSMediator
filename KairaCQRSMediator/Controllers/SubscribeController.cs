using KairaCQRSMediator.Features.Mediator.Commands.SubscribeCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IMediator _mediator;

        public SubscribeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string email)
        {
            try
            {
                await _mediator.Send(new CreateSubscribeCommand
                {
                    Email = email,
                    SubscribeDate = DateTime.Now,
                    IsActive = true
                });

                return Json(new { success = true, message = "Aboneliğiniz başarıyla oluşturuldu!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Bir hata oluştu: " + ex.Message });
            }
        }
    }
}