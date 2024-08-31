using Domain.Entities;
using Domain.Shared;

namespace Domain.Events.EmployeeEvents;

public class EmployeeCreatedEvent : DomainEvent
{
    public Employee Employee { get; }

    public EmployeeCreatedEvent(Employee employee)
    {
        Employee = employee;
    }
}
