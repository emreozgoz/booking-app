using HouseBookingApp.Application.Common.Interfaces;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Commands.SetAvailability;

public class SetAvailabilityCommandHandler : IRequestHandler<SetAvailabilityCommand, Unit>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetAvailabilityCommandHandler(
        IRoomRepository roomRepository,
        IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SetAvailabilityCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        
        if (room == null)
            throw new ArgumentException($"Room with ID {request.RoomId} not found");

        room.SetAvailability(request.Date, request.IsAvailable);

        await _roomRepository.UpdateAsync(room, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}