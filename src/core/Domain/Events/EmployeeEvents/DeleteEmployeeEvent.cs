using Domain.Entities;
using Domain.Shared;

namespace Domain.Events.EmployeeEvents;

public class DeleteEmployeeEvent : DomainEvent
{
    public Employee Employee { get; }

    public DeleteEmployeeEvent(Employee employee)
    {
        Employee = employee;
    }
}
