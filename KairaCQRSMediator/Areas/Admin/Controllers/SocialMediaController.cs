using KairaCQRSMediator.Features.Mediator.Commands.SocialMediaCommands;
using KairaCQRSMediator.Features.Mediator.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var socialMedia = await _mediator.Send(new GetSocialMediaQuery());
            return View(socialMedia);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "Sosyal medya başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Update(int id)
        {
            var socialMedia = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            var command = new UpdateSocialMediaCommand
            {
                SocialMediaId = socialMedia.SocialMediaId,
                Platform = socialMedia.Platform,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSocialMediaCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                TempData["Success"] = "Sosyal medya başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var socialMedia = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return View(socialMedia);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            TempData["Success"] = "Sosyal medya başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }
    }
}