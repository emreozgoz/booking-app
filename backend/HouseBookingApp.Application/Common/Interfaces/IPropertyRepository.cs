using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IPropertyRepository
{
    Task<Property?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Property>> GetPropertiesAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm = null,
        bool? isActive = null,
        Guid? ownerId = null,
        Location? location = null,
        PropertyType? propertyType = null,
        CancellationToken cancellationToken = default);
    Task<int> GetPropertiesCountAsync(
        string? searchTerm = null,
        bool? isActive = null,
        Guid? ownerId = null,
        Location? location = null,
        PropertyType? propertyType = null,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Property>> GetByOwnerAsync(Guid ownerId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Property>> GetAvailablePropertiesAsync(
        Period period,
        Location? location = null,
        PropertyType? propertyType = null,
        CancellationToken cancellationToken = default);
    Task AddAsync(Property property, CancellationToken cancellationToken = default);
    Task UpdateAsync(Property property, CancellationToken cancellationToken = default);
    Task DeleteAsync(Property property, CancellationToken cancellationToken = default);
}