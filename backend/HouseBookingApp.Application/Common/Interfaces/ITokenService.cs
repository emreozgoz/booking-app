using DomainUser = HouseBookingApp.Domain.Entities.User;

namespace HouseBookingApp.Application.Common.Interfaces;

public interface ITokenService
{
    string GenerateToken(DomainUser user);
    string GenerateRefreshToken();
    bool ValidateToken(string token);
    Guid GetUserIdFromToken(string token);
}