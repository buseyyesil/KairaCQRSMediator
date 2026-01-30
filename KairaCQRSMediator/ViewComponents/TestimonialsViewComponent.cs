using KairaCQRSMediator.Features.CQRS.Handlers.TestimonialHandlers;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly GetTestimonialQueryHandler _getTestimonialQueryHandler;

        public TestimonialsViewComponent(GetTestimonialQueryHandler getTestimonialQueryHandler)
        {
            _getTestimonialQueryHandler = getTestimonialQueryHandler;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await _getTestimonialQueryHandler.Handle();
            return View(testimonials);
        }
    }
}