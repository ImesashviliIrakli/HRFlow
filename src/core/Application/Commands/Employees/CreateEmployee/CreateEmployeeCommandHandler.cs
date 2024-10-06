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
    private readonly IMediator _mediator;

    public CreateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository,
        IAuthService authService,
        IUnitOfWork unitOfWork,
        IMediator mediator
        )
    {
        _employeeRepository = employeeRepository;
        _authService = authService;
        _unitOfWork = unitOfWork;
        _mediator = mediator;
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

        var domainEvents = employee.DomainEvents;

        foreach (var item in domainEvents)
        {
            await _mediator.Publish(item, cancellationToken);
        }

        return employee.Id;
    }
}
