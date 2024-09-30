using Application.Interfaces.Messaging;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Employees.UpdateEmployeeDetails;

public class UpdateEmployeeDetailsCommandHandler : ICommandHandler<UpdateEmployeeDetailsCommand, Unit>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateEmployeeDetailsCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Unit>> Handle(UpdateEmployeeDetailsCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee is null)
            return Result.Failure<Unit>(DomainErrors.Employee.NotFound(request.EmployeeId.ToString()));

        var newAddress = new Address(request.Street, request.City, request.State, request.ZipCode);

        employee.UpdateEmployeeDetails(request.FirstName, request.LastName, request.Position, newAddress);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
