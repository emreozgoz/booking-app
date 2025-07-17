using MediatR;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Houses.Commands;

public class CreateHouseCommand : IRequest<House>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal PricePerNight { get; set; }
    public int MaxGuests { get; set; }
    public int Bedrooms { get; set; }
    public int Bathrooms { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public Guid OwnerId { get; set; }
}