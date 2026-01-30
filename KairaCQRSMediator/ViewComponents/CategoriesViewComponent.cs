using KairaCQRSMediator.Features.CQRS.Handlers.CategoryHandles;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        public CategoriesViewComponent(GetCategoryQueryHandler getCategoryQueryHandler)
        {
            _getCategoryQueryHandler = getCategoryQueryHandler;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _getCategoryQueryHandler.Handle();
            return View(categories);
        }
    }
}
