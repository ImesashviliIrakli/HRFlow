using MediatR;

namespace Application.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommand : IRequest<Unit>
{
    public Guid EmployeeId { get; }

    public DeleteEmployeeCommand(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}
