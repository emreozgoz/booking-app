using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.ActivateProperty;

public record ActivatePropertyCommand(Guid Id) : IRequest<Unit>;