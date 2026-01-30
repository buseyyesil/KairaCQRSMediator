using KairaCQRSMediator.DataAccess.Context;
using KairaCQRSMediator.Features.Mediator.Queries.ContactInfoQueries;
using KairaCQRSMediator.Features.Mediator.Results.ContactInfoResults;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KairaCQRSMediator.Features.Mediator.Handlers.ContactInfoHandlers
{
    public class GetContactInfoQueryHandler : IRequestHandler<GetContactInfoQuery, GetContactInfoQueryResult>
    {
        private readonly KairaContext _context;

        public GetContactInfoQueryHandler(KairaContext context)
        {
            _context = context;
        }

        public async Task<GetContactInfoQueryResult> Handle(GetContactInfoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var value = await _context.ContactInfos.FirstOrDefaultAsync(cancellationToken);

                if (value == null)
                {
                    return new GetContactInfoQueryResult
                    {
                        ContactInfoId = 0,
                        Phone = "",
                        Email = "",
                        Address = "",
                        WorkingHours = ""
                    };
                }

                return new GetContactInfoQueryResult
                {
                    ContactInfoId = value.ContactInfoId,
                    Phone = value.Phone ?? "",
                    Email = value.Email ?? "",
                    Address = value.Address ?? "",
                    WorkingHours = value.WorkingHours ?? ""
                };
            }
            catch (Exception ex)
            {
                // Hata durumunda boş nesne döndür
                return new GetContactInfoQueryResult
                {
                    ContactInfoId = 0,
                    Phone = "",
                    Email = "",
                    Address = "",
                    WorkingHours = ""
                };
            }
        }
    }
}