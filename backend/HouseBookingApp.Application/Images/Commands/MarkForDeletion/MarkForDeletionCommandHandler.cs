using HouseBookingApp.Application.Common.Interfaces;
using MediatR;

namespace HouseBookingApp.Application.Images.Commands.MarkForDeletion;

public class MarkForDeletionCommandHandler : IRequestHandler<MarkForDeletionCommand, Unit>
{
    private readonly IImageRepository _imageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public MarkForDeletionCommandHandler(
        IImageRepository imageRepository,
        IUnitOfWork unitOfWork)
    {
        _imageRepository = imageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(MarkForDeletionCommand request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAsync(request.ImageId, cancellationToken);
        
        if (image == null)
            throw new ArgumentException($"Image with ID {request.ImageId} not found");

        image.MarkForDeletion();

        await _imageRepository.UpdateAsync(image, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}