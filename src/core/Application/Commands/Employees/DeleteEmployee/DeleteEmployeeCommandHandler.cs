using Application.Interfaces;
using MediatR;

namespace Application.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    private readonly IEmployeeRepository _repository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
    {
        _repository = repository;
    }
    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
            throw new Exception("Not Found");

        employee.DeleteEmployee();

        await _repository.DeleteAsync(employee);

        return Unit.Value;
    }
}
