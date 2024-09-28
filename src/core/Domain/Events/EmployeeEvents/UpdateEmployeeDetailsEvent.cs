using Domain.Entities;
using Domain.Primitives;

namespace Domain.Events.EmployeeEvents;

public class UpdateEmployeeDetailsEvent : DomainEvent
{
    public Employee Employee { get; }

    public UpdateEmployeeDetailsEvent(Employee employee)
    {
        Employee = employee;
    }
}
