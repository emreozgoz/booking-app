using HouseBookingApp.Application.Common.Interfaces;
using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.DeactivateProperty;

public class DeactivatePropertyCommandHandler : IRequestHandler<DeactivatePropertyCommand, Unit>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeactivatePropertyCommandHandler(
        IPropertyRepository propertyRepository,
        IUnitOfWork unitOfWork)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeactivatePropertyCommand request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (property == null)
            throw new ArgumentException($"Property with ID {request.Id} not found");

        property.Deactivate();

        await _propertyRepository.UpdateAsync(property, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}