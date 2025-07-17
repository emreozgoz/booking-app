using HouseBookingApp.Domain.Common;
using HouseBookingApp.Domain.Enums;
using HouseBookingApp.Domain.ValueObjects;
using HouseBookingApp.Domain.Events;

namespace HouseBookingApp.Domain.Entities;

public class User : AggregateRoot<UserId>
{
    public Email Email { get; private set; }
    public string PasswordHash { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserRole Role { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime? LastLoginAt { get; private set; }
    public string? EmailVerificationToken { get; private set; }
    public DateTime? EmailVerificationTokenExpiry { get; private set; }

    // Navigation properties
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    private User() { }

    public static User Create(
        UserId id,
        Email email,
        string passwordHash,
        string firstName,
        string lastName,
        UserRole role = UserRole.Guest)
    {
        var user = new User
        {
            Id = id,
            Email = email,
            PasswordHash = passwordHash,
            FirstName = firstName,
            LastName = lastName,
            Role = role,
            IsEmailVerified = false,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            EmailVerificationToken = Guid.NewGuid().ToString(),
            EmailVerificationTokenExpiry = DateTime.UtcNow.AddHours(24)
        };

        user.RaiseDomainEvent(new UserRegisteredDomainEvent(user.Id, user.Email, user.EmailVerificationToken));
        return user;
    }

    public string FullName => $"{FirstName} {LastName}";

    public bool IsPropertyOwner => Role == UserRole.PropertyOwner || Role == UserRole.Admin;
    public bool IsAdmin => Role == UserRole.Admin;
    public bool IsGuest => Role == UserRole.Guest;

    public void VerifyEmail(string token)
    {
        if (IsEmailVerified)
            throw new DomainException("Email already verified");

        if (EmailVerificationToken != token)
            throw new DomainException("Invalid verification token");

        if (EmailVerificationTokenExpiry < DateTime.UtcNow)
            throw new DomainException("Verification token expired");

        IsEmailVerified = true;
        EmailVerificationToken = null;
        EmailVerificationTokenExpiry = null;
        UpdatedAt = DateTime.UtcNow;

        RaiseDomainEvent(new UserEmailVerifiedDomainEvent(Id, Email));
    }

    public void ChangePassword(string currentPasswordHash, string newPasswordHash)
    {
        if (!IsActive)
            throw new DomainException("Cannot change password for inactive user");

        if (PasswordHash != currentPasswordHash)
            throw new DomainException("Current password is incorrect");

        PasswordHash = newPasswordHash;
        UpdatedAt = DateTime.UtcNow;
        RaiseDomainEvent(new UserPasswordChangedDomainEvent(Id, Email));
    }

    public void UpdateLastLogin()
    {
        LastLoginAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string firstName, string lastName)
    {
        if (!IsActive)
            throw new DomainException("Cannot update profile for inactive user");

        FirstName = firstName;
        LastName = lastName;
        UpdatedAt = DateTime.UtcNow;

        RaiseDomainEvent(new UserProfileUpdatedDomainEvent(Id, firstName, lastName));
    }

    public void ChangeRole(UserRole newRole)
    {
        if (!IsActive)
            throw new DomainException("Cannot change role for inactive user");

        var oldRole = Role;
        Role = newRole;
        UpdatedAt = DateTime.UtcNow;

        RaiseDomainEvent(new UserRoleChangedDomainEvent(Id, oldRole, newRole));
    }

    public void DeactivateAccount()
    {
        if (!IsActive)
            throw new DomainException("User is already inactive");

        IsActive = false;
        UpdatedAt = DateTime.UtcNow;
        RaiseDomainEvent(new UserAccountDeactivatedDomainEvent(Id, Email));
    }
}