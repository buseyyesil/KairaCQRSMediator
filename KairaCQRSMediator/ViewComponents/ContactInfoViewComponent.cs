using KairaCQRSMediator.Features.Mediator.Queries.ContactInfoQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KairaCQRSMediator.ViewComponents
{
    public class ContactInfoViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;

        public ContactInfoViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contactInfo = await _mediator.Send(new GetContactInfoQuery());
            return View(contactInfo);
        }
    }
}