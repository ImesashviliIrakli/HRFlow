using Domain.Entities;
using Domain.Shared;

namespace Domain.Events.EmployeeEvents;

public class LeaveRequestAddedEvent : DomainEvent
{
    public LeaveRequest LeaveRequest { get; }

    public LeaveRequestAddedEvent(LeaveRequest leaveRequest)
    {
        LeaveRequest = leaveRequest;
    }
}
