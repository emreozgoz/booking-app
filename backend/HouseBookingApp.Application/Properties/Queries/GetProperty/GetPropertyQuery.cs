using HouseBookingApp.Application.DTOs.Properties;
using MediatR;

namespace HouseBookingApp.Application.Properties.Queries.GetProperty;

public record GetPropertyQuery(Guid Id) : IRequest<PropertyDto>;