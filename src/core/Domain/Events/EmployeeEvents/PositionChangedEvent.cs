using Domain.Entities;
using Domain.Shared;

namespace Domain.Events.EmployeeEvents;

public class PositionChangedEvent : DomainEvent
{
    public Employee Employee { get; }

    public PositionChangedEvent(Employee employee)
    {
        Employee = employee;
    }
}
