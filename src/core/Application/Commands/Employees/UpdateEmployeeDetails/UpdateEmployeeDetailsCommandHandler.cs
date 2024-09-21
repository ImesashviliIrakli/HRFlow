using Application.Interfaces;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Employees.UpdateEmployeeDetails;

public class UpdateEmployeeDetailsCommandHandler : IRequestHandler<UpdateEmployeeDetailsCommand, Unit>
{
    private readonly IEmployeeRepository _repository;
    public UpdateEmployeeDetailsCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(UpdateEmployeeDetailsCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee is null)
            throw new Exception("Not Found");

        var newAddress = new Address(request.Street, request.City, request.State, request.ZipCode);

        employee.UpdateEmployeeDetails(request.FirstName, request.LastName, request.Position, newAddress);

        await _repository.UpdateAsync(employee);

        return Unit.Value;
    }
}
