using HouseBookingApp.Application.DTOs.Images;
using MediatR;

namespace HouseBookingApp.Application.Images.Queries.GetImage;

public record GetImageQuery(Guid Id) : IRequest<ImageDto>;