using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Results.TestimonialResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle()
        {
            var testimonials = await _repository.GetAllAsync();
            return testimonials.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                CustomerName = x.CustomerName,
                Comment = x.Comment,
                Title = x.Title,
                Rating = x.Rating,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}