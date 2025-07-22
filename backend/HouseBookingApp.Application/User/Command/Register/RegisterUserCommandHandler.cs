using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.Entities;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.User.Command.Register;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        
        var existingUser = await _userRepository.GetByEmailAsync(email, cancellationToken);
        if (existingUser != null)
            throw new InvalidOperationException("User with this email already exists");

        var passwordHash = _passwordHasher.HashPassword(request.Password);
        var userId = UserId.Create();

        var user = HouseBookingApp.Domain.Entities.User.Create(
            userId.Value,
            email,
            passwordHash,
            request.FirstName,
            request.LastName);

        await _userRepository.AddAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new RegisterUserResponse(
            user.Id,
            user.Email.Value,
            user.EmailVerificationToken!,
            "User registered successfully");
    }
}