using MediatR;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Houses.Queries;

public class GetHouseByIdQuery : IRequest<House?>
{
    public Guid Id { get; set; }

    public GetHouseByIdQuery(Guid id)
    {
        Id = id;
    }
}