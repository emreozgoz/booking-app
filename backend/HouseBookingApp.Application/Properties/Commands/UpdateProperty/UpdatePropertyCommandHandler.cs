using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Properties;
using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.UpdateProperty;

public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, PropertyDto>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePropertyCommandHandler(
        IPropertyRepository propertyRepository,
        IUnitOfWork unitOfWork)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PropertyDto> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (property == null)
            throw new ArgumentException($"Property with ID {request.Id} not found");

        property.UpdateDetails(
            request.Name,
            request.Description,
            request.Location,
            request.PropertyType);

        await _propertyRepository.UpdateAsync(property, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new PropertyDto
        {
            Id = property.Id,
            Name = property.Name,
            Description = property.Description,
            PropertyType = property.PropertyType,
            Location = property.Location,
            OwnerId = property.OwnerId,
            IsActive = property.IsActive,
            ImageUrl = property.ImageUrl,
            Rating = property.Rating,
            ReviewCount = property.ReviewCount,
            CreatedAt = property.CreatedAt,
            UpdatedAt = property.UpdatedAt
        };
    }
}