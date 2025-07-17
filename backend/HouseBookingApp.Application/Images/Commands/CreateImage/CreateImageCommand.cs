using HouseBookingApp.Application.DTOs.Images;
using MediatR;

namespace HouseBookingApp.Application.Images.Commands.CreateImage;

public record CreateImageCommand(
    string Url,
    string Alt = "",
    bool IsPrimary = false,
    int Order = 0
) : IRequest<ImageDto>;