using HouseBookingApp.Application.DTOs.Images;
using MediatR;

namespace HouseBookingApp.Application.Images.Commands.SetAsPrimary;

public record SetAsPrimaryCommand(Guid ImageId) : IRequest<ImageDto>;