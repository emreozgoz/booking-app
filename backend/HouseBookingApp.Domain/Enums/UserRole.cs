namespace HouseBookingApp.Domain.Enums;

public enum UserRole
{
    Guest = 1,
    PropertyOwner = 2,
    Admin = 3
}

public static class UserRoleExtensions
{
    public static string GetDisplayName(this UserRole role)
    {
        return role switch
        {
            UserRole.Guest => "Guest",
            UserRole.PropertyOwner => "Property Owner",
            UserRole.Admin => "Administrator",
            _ => role.ToString()
        };
    }

    public static bool HasPermission(this UserRole role, string permission)
    {
        return role switch
        {
            UserRole.Admin => true,
            UserRole.PropertyOwner => permission switch
            {
                "ManageProperties" => true,
                "ViewReservations" => true,
                "ManageRooms" => true,
                _ => false
            },
            UserRole.Guest => permission switch
            {
                "MakeReservation" => true,
                "ViewOwnReservations" => true,
                "WriteReview" => true,
                _ => false
            },
            _ => false
        };
    }
}