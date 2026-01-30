using KairaCQRSMediator.Features.CQRS.Commands.TestimonialCommands;
using KairaCQRSMediator.Features.CQRS.Handlers.TestimonialHandlers;
using KairaCQRSMediator.Features.CQRS.Queries.TestimonialQueries;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;
        private readonly GetTestimonialByIdQueryHandler _getTestimonialByIdQueryHandler;
        private readonly CreateTestimonialCommandHandler _createTestimonialCommandHandler;
        private readonly UpdateTestimonialCommandHandler _updateTestimonialCommandHandler;
        private readonly RemoveTestimonialCommandHandler _removeTestimonialCommandHandler;

        public TestimonialController(GetTestimonialQueryHandler getTestimonialQueryHandler, GetTestimonialByIdQueryHandler getTestimonialByIdQueryHandler, CreateTestimonialCommandHandler createTestimonialCommandHandler, UpdateTestimonialCommandHandler updateTestimonialCommandHandler, RemoveTestimonialCommandHandler removeTestimonialCommandHandler)
        {
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
            _getTestimonialByIdQueryHandler = getTestimonialByIdQueryHandler;
            _createTestimonialCommandHandler = createTestimonialCommandHandler;
            _updateTestimonialCommandHandler = updateTestimonialCommandHandler;
            _removeTestimonialCommandHandler = removeTestimonialCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var testimonials = await _getTestimonialQueryHandler.Handle();
            return View(testimonials);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand command)
        {
            if (ModelState.IsValid)
            {
                await _createTestimonialCommandHandler.Handle(command);
                TempData["Success"] = "Yorum başarıyla eklendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Update(int id)
        {
            var testimonial = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            var command = new UpdateTestimonialCommand { TestimonialId = testimonial.TestimonialId, CustomerName = testimonial.CustomerName, Comment = testimonial.Comment, Title = testimonial.Title, Rating = testimonial.Rating, ImageUrl = testimonial.ImageUrl };
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTestimonialCommand command)
        {
            if (ModelState.IsValid)
            {
                await _updateTestimonialCommandHandler.Handle(command);
                TempData["Success"] = "Yorum başarıyla güncellendi!";
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            return View(testimonial);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            TempData["Success"] = "Yorum başarıyla silindi!";
            return RedirectToAction(nameof(Index));
        }
    }
}