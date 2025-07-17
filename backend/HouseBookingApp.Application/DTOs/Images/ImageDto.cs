namespace HouseBookingApp.Application.DTOs.Images;

public class ImageDto
{
    public Guid Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public bool IsPrimary { get; set; }
    public bool IsMarkedForDeletion { get; set; }
    public DateTime? MarkedForDeletionAt { get; set; }
    public string Alt { get; set; } = string.Empty;
    public int Order { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}