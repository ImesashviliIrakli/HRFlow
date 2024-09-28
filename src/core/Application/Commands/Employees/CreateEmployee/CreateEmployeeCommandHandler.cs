using Application.Interfaces;
using Application.Interfaces.Messaging;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using MediatR;

namespace Application.Commands.Employees.CreateEmployee;

public class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand, Guid>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository,
        IAuthService authService,
        IUnitOfWork unitOfWork
        )
    {
        _employeeRepository = employeeRepository;
        _authService = authService;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _authService.RegisterAsync(request.RegistrationRequest);

        if (user is null)
            return Result.Failure<Guid>(DomainErrors.Employee.FailedRegistration);

        var address = new Address(request.CreateEmployeeDto.Street, request.CreateEmployeeDto.City, request.CreateEmployeeDto.State, request.CreateEmployeeDto.ZipCode);

        var employee = new Employee(user.UserId, request.RegistrationRequest.FirstName, request.RegistrationRequest.LastName, request.CreateEmployeeDto.Position, address);

        await _employeeRepository.AddAsync(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
