using Domain.Entities;
using Domain.Primitives;

namespace Domain.Events.EmployeeEvents;

public class LeaveRequestAddedEvent : DomainEvent
{
    public LeaveRequest LeaveRequest { get; }

    public LeaveRequestAddedEvent(LeaveRequest leaveRequest)
    {
        LeaveRequest = leaveRequest;
    }
}
