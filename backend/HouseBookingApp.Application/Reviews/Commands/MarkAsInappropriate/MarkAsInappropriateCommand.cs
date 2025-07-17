using MediatR;

namespace HouseBookingApp.Application.Reviews.Commands.MarkAsInappropriate;

public record MarkAsInappropriateCommand(Guid ReviewId) : IRequest<Unit>;