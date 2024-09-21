using Domain.Entities;
using Domain.Shared;

namespace Domain.Events.EmployeeEvents;

public class UpdateEmployeeDetailsEvent : DomainEvent
{
    public Employee Employee { get; }

    public UpdateEmployeeDetailsEvent(Employee employee)
    {
        Employee = employee;
    }
}
