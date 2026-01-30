using KairaCQRSMediator.Features.Mediator.Queries.SubscribeQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private readonly IMediator _mediator;

        public SubscribeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var subscribes = await _mediator.Send(new GetSubscribeQuery());
            return View(subscribes);
        }
    }
}