using HouseBookingApp.Application.DTOs.Properties;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.Properties.Queries.GetProperties;

public record GetPropertiesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string? SearchTerm = null,
    bool? IsActive = null,
    Guid? OwnerId = null,
    Location? Location = null,
    PropertyType? PropertyType = null
) : IRequest<GetPropertiesResponse>;

public class GetPropertiesResponse
{
    public List<PropertySummaryDto> Properties { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}