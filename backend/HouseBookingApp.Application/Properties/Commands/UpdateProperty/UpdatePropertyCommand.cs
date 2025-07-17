using HouseBookingApp.Application.DTOs.Properties;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.UpdateProperty;

public record UpdatePropertyCommand(
    Guid Id,
    string Name,
    string Description,
    PropertyType PropertyType,
    Location Location
) : IRequest<PropertyDto>;