using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Application.DTOs.Properties;
using MediatR;

namespace HouseBookingApp.Application.Properties.Queries.GetProperties;

public class GetPropertiesQueryHandler : IRequestHandler<GetPropertiesQuery, GetPropertiesResponse>
{
    private readonly IPropertyRepository _propertyRepository;

    public GetPropertiesQueryHandler(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<GetPropertiesResponse> Handle(GetPropertiesQuery request, CancellationToken cancellationToken)
    {
        var properties = await _propertyRepository.GetPropertiesAsync(
            request.PageNumber,
            request.PageSize,
            request.SearchTerm,
            request.IsActive,
            request.OwnerId,
            request.Location,
            request.PropertyType,
            cancellationToken);

        var totalCount = await _propertyRepository.GetPropertiesCountAsync(
            request.SearchTerm,
            request.IsActive,
            request.OwnerId,
            request.Location,
            request.PropertyType,
            cancellationToken);

        return new GetPropertiesResponse
        {
            Properties = properties.Select(p => new PropertySummaryDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                PropertyType = p.PropertyType,
                Location = p.Location,
                IsActive = p.IsActive,
                ImageUrl = p.ImageUrl,
                Rating = p.Rating,
                ReviewCount = p.ReviewCount,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList(),
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}