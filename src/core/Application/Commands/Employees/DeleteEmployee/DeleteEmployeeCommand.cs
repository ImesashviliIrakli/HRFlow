using Application.Interfaces.Messaging;
using MediatR;

namespace Application.Commands.Employees.DeleteEmployee;

public class DeleteEmployeeCommand : ICommand<Unit>
{
    public Guid EmployeeId { get; }

    public DeleteEmployeeCommand(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}
