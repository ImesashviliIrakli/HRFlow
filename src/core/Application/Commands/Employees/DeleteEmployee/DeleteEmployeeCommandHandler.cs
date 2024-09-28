using Application.Interfaces.Messaging;
using Domain.Errors;
using Domain.Repositories;
using Domain.Shared;
using MediatR;

namespace Application.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommandHandler : ICommandHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<Unit>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
            return Result.Failure<Unit>(DomainErrors.Employee.NotFound(request.EmployeeId.ToString()));

        employee.DeleteEmployee();

        _employeeRepository.Delete(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
