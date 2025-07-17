using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.DeactivateProperty;

public record DeactivatePropertyCommand(Guid Id) : IRequest<Unit>;