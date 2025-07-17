using MediatR;

namespace HouseBookingApp.Application.Images.Commands.MarkForDeletion;

public record MarkForDeletionCommand(Guid ImageId) : IRequest<Unit>;