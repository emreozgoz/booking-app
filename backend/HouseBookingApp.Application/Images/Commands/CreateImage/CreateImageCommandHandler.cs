using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Images;
using HouseBookingApp.Domain.Entities;
using MediatR;

namespace HouseBookingApp.Application.Images.Commands.CreateImage;

public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageDto>
{
    private readonly IImageRepository _imageRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateImageCommandHandler(
        IImageRepository imageRepository,
        IUnitOfWork unitOfWork)
    {
        _imageRepository = imageRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ImageDto> Handle(CreateImageCommand request, CancellationToken cancellationToken)
    {
        var image = new Image(
            request.Url,
            request.Alt,
            request.IsPrimary,
            request.Order);

        await _imageRepository.AddAsync(image, cancellationToken);
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