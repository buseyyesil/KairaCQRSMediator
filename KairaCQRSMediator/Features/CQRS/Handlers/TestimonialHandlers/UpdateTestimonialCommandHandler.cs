using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.TestimonialCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand command)
        {
            var testimonial = new Testimonial
            {
                TestimonialId = command.TestimonialId,
                CustomerName = command.CustomerName,
                Comment = command.Comment,
                Title = command.Title,
                Rating = command.Rating,
                ImageUrl = command.ImageUrl
            };
            await _repository.UpdateAsync(testimonial);
        }
    }
}