using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Employees.CreateEmployee;

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAuthService _authService;

    public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IAuthService authService)
    {
        _employeeRepository = employeeRepository;
        _authService = authService;
    }

    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService.RegisterAsync(request.RegistrationRequest);

        var address = new Address(request.CreateEmployeeDto.Street, request.CreateEmployeeDto.City, request.CreateEmployeeDto.State, request.CreateEmployeeDto.ZipCode);

        var employee = new Employee(user.UserId, request.RegistrationRequest.FirstName, request.RegistrationRequest.LastName, request.CreateEmployeeDto.Position, address);

        // Add the new Employee to the repository
        await _employeeRepository.AddAsync(employee);

        return employee.Id;
    }
}
