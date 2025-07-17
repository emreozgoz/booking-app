using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Images;
using MediatR;

namespace HouseBookingApp.Application.Images.Queries.GetImage;

public class GetImageQueryHandler : IRequestHandler<GetImageQuery, ImageDto>
{
    private readonly IImageRepository _imageRepository;

    public GetImageQueryHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<ImageDto> Handle(GetImageQuery request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (image == null)
            throw new ArgumentException($"Image with ID {request.Id} not found");

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