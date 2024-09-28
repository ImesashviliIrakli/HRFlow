using Domain.Entities;
using Domain.Primitives;

namespace Domain.Events.EmployeeEvents;

public class DeleteEmployeeEvent : DomainEvent
{
    public Employee Employee { get; }

    public DeleteEmployeeEvent(Employee employee)
    {
        Employee = employee;
    }
}
