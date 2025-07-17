using HouseBookingApp.Application.DTOs.Properties;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.CreateProperty;

public record CreatePropertyCommand(
    string Name,
    string Description,
    PropertyType PropertyType,
    Location Location,
    Guid OwnerId
) : IRequest<PropertyDto>;