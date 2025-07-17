using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Properties;
using HouseBookingApp.Domain.Entities;
using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.CreateProperty;

public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, PropertyDto>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePropertyCommandHandler(
        IPropertyRepository propertyRepository,
        IUnitOfWork unitOfWork)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PropertyDto> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
    {
        var property = Property.Create(
            request.Name,
            request.Location,
            request.Description,
            request.PropertyType,
            request.OwnerId);

        await _propertyRepository.AddAsync(property, cancellationToken);
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