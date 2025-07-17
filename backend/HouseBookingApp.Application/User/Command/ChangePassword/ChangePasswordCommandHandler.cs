using HouseBookingApp.Application.Common.Interfaces;
using HouseBookingApp.Domain.ValueObjects;
using MediatR;

namespace HouseBookingApp.Application.User.Command.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var userId = UserId.Create(request.UserId);
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);

        if (user == null)
            throw new InvalidOperationException("User not found");

        var currentPasswordHash = _passwordHasher.HashPassword(request.CurrentPassword);
        var newPasswordHash = _passwordHasher.HashPassword(request.NewPassword);

        user.ChangePassword(currentPasswordHash, newPasswordHash);

        await _userRepository.UpdateAsync(user, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new ChangePasswordResponse(true, "Password changed successfully");
    }
}