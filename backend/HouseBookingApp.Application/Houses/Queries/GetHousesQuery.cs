using MediatR;
using HouseBookingApp.Domain.Entities;

namespace HouseBookingApp.Application.Houses.Queries;

public class GetHousesQuery : IRequest<List<House>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? SearchTerm { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
}