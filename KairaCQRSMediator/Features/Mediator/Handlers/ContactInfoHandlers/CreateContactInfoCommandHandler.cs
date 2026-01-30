using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.Mediator.Commands.ContactInfoCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand>
    {
        private readonly KairaContext _context;

        public CreateContactInfoCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            _context.ContactInfos.Add(new ContactInfo
            {
                Phone = request.Phone,
                Email = request.Email,
                Address = request.Address,
                WorkingHours = request.WorkingHours
            });
            await _context.SaveChangesAsync();
        }
    }
}