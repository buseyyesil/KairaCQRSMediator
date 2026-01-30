using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Queries.TestimonialQueries;
using KairaCQRSMediator.Features.CQRS.Results.TestimonialResults;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery query)
        {
            var testimonial = await _repository.GetByIdAsync(query.Id);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = testimonial.TestimonialId,
                CustomerName = testimonial.CustomerName,
                Comment = testimonial.Comment,
                Title = testimonial.Title,
                Rating = testimonial.Rating,
                ImageUrl = testimonial.ImageUrl
            };
        }
    }
}
