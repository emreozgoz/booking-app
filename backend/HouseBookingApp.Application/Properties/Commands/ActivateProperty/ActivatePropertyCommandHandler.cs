using HouseBookingApp.Application.Common.Interfaces;
using MediatR;

namespace HouseBookingApp.Application.Properties.Commands.ActivateProperty;

public class ActivatePropertyCommandHandler : IRequestHandler<ActivatePropertyCommand, Unit>
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActivatePropertyCommandHandler(
        IPropertyRepository propertyRepository,
        IUnitOfWork unitOfWork)
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(ActivatePropertyCommand request, CancellationToken cancellationToken)
    {
        var property = await _propertyRepository.GetByIdAsync(request.Id, cancellationToken);
        
        if (property == null)
            throw new ArgumentException($"Property with ID {request.Id} not found");

        property.Activate();

        await _propertyRepository.UpdateAsync(property, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}