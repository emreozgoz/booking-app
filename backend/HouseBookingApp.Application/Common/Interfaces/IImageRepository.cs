using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface IImageRepository
{
    Task<Image?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Image>> GetImagesAsync(
        int pageNumber,
        int pageSize,
        bool? isPrimary = null,
        bool? isMarkedForDeletion = null,
        CancellationToken cancellationToken = default);
    Task<int> GetImagesCountAsync(
        bool? isPrimary = null,
        bool? isMarkedForDeletion = null,
        CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Image>> GetByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Image>> GetByRoomAsync(Guid roomId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Image>> GetMarkedForDeletionAsync(CancellationToken cancellationToken = default);
    Task<Image?> GetPrimaryImageByPropertyAsync(Guid propertyId, CancellationToken cancellationToken = default);
    Task<Image?> GetPrimaryImageByRoomAsync(Guid roomId, CancellationToken cancellationToken = default);
    Task AddAsync(Image image, CancellationToken cancellationToken = default);
    Task UpdateAsync(Image image, CancellationToken cancellationToken = default);
    Task DeleteAsync(Image image, CancellationToken cancellationToken = default);
}