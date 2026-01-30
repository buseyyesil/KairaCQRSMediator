using KairaCQRSMediator.DataAccess.Entities;
using KairaCQRSMediator.Features.CQRS.Commands.TestimonialCommands;
using KairaCQRSMediator.Repositories;

namespace KairaCQRSMediator.Features.CQRS.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonialCommand command)
        {
            var testimonial = new Testimonial
            {
                CustomerName = command.CustomerName,
                Comment = command.Comment,
                Title = command.Title,
                Rating = command.Rating,
                ImageUrl = command.ImageUrl
            };
            await _repository.CreateAsync(testimonial);
        }
    }
}