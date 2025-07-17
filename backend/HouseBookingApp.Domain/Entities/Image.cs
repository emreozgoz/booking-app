using HouseBookingApp.Domain.Common;

namespace HouseBookingApp.Domain.Entities;

public class Image : BaseEntity
{
    public string Url { get; private set; } = string.Empty;
    public bool IsPrimary { get; private set; } = false;
    public bool IsMarkedForDeletion { get; private set; } = false;
    public DateTime? MarkedForDeletionAt { get; private set; }
    public string Alt { get; private set; } = string.Empty;
    public int Order { get; private set; } = 0;

    protected Image() { }

    public Image(string url, string alt = "", bool isPrimary = false, int order = 0)
    {
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Image URL cannot be empty");

        Url = url;
        Alt = alt;
        IsPrimary = isPrimary;
        Order = order;
    }

    public void SetAsPrimary()
    {
        if (IsMarkedForDeletion)
            throw new InvalidOperationException("Cannot set a deleted image as primary");

        IsPrimary = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveAsPrimary()
    {
        IsPrimary = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void MarkForDeletion()
    {
        if (IsMarkedForDeletion)
            throw new InvalidOperationException("Image is already marked for deletion");

        IsMarkedForDeletion = true;
        IsPrimary = false; // Remove primary status when marking for deletion
        MarkedForDeletionAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UnmarkForDeletion()
    {
        if (!IsMarkedForDeletion)
            throw new InvalidOperationException("Image is not marked for deletion");

        IsMarkedForDeletion = false;
        MarkedForDeletionAt = null;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateOrder(int newOrder)
    {
        if (IsMarkedForDeletion)
            throw new InvalidOperationException("Cannot update order of a deleted image");

        Order = newOrder;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateDetails(string url, string alt)
    {
        if (IsMarkedForDeletion)
            throw new InvalidOperationException("Cannot update details of a deleted image");

        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentException("Image URL cannot be empty");

        Url = url;
        Alt = alt;
        UpdatedAt = DateTime.UtcNow;
    }
}