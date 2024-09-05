using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Employees.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var address = new Address(request.Street, request.City, request.State, request.ZipCode);

        var employee = new Employee(request.FirstName, request.LastName, request.Position, address);

        // Add the new Employee to the repository
        await _employeeRepository.AddAsync(employee);

        return employee.Id;
    }
}
