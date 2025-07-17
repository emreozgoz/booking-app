using HouseBookingApp.Application.Common.Interfaces;
using MediatR;

namespace HouseBookingApp.Application.Rooms.Commands.SetPriceOverride;

public class SetPriceOverrideCommandHandler : IRequestHandler<SetPriceOverrideCommand, Unit>
{
    private readonly IRoomRepository _roomRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetPriceOverrideCommandHandler(
        IRoomRepository roomRepository,
        IUnitOfWork unitOfWork)
    {
        _roomRepository = roomRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(SetPriceOverrideCommand request, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(request.RoomId, cancellationToken);
        
        if (room == null)
            throw new ArgumentException($"Room with ID {request.RoomId} not found");

        room.SetPriceOverride(request.Date, request.Price);

        await _roomRepository.UpdateAsync(room, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}