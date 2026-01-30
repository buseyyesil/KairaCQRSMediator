using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Commands.ContactInfoCommands;
using MediatR;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class UpdateContactInfoCommandHandler : IRequestHandler<UpdateContactInfoCommand>
    {
        private readonly KairaContext _context;

        public UpdateContactInfoCommandHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateContactInfoCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.ContactInfos.FindAsync(request.ContactInfoId);
            value.Phone = request.Phone;
            value.Email = request.Email;
            value.Address = request.Address;
            value.WorkingHours = request.WorkingHours;
            await _context.SaveChangesAsync();
        }
    }
}