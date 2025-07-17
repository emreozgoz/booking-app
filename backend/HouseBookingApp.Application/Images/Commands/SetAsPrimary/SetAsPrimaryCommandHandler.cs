using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Images;
using MediatR;

namespace HouseBookingApp.Application.Images.Commands.SetAsPrimary;

public class SetAsPrimaryCommandHandler : IRequestHandler<SetAsPrimaryCommand, ImageDto>
{
    private readonly IImageRepository _imageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SetAsPrimaryCommandHandler(
        IImageRepository imageRepository,
        IUnitOfWork unitOfWork)
    {
        _imageRepository = imageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ImageDto> Handle(SetAsPrimaryCommand request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAsync(request.ImageId, cancellationToken);
        
        if (image == null)
            throw new ArgumentException($"Image with ID {request.ImageId} not found");

        image.SetAsPrimary();

        await _imageRepository.UpdateAsync(image, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ImageDto
        {
            Id = image.Id,
            Url = image.Url,
            IsPrimary = image.IsPrimary,
            IsMarkedForDeletion = image.IsMarkedForDeletion,
            MarkedForDeletionAt = image.MarkedForDeletionAt,
            Alt = image.Alt,
            Order = image.Order,
            CreatedAt = image.CreatedAt,
            UpdatedAt = image.UpdatedAt
        };
    }
}