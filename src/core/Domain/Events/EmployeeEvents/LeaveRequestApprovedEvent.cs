using Domain.Primitives;

namespace Domain.Events.EmployeeEvents;

public class LeaveRequestApprovedEvent : DomainEvent
{
    public Guid LeaveRequestId { get; }
    public DateTime ApprovalDate { get; }

    public LeaveRequestApprovedEvent(Guid leaveRequestId)
    {
        LeaveRequestId = leaveRequestId;
        ApprovalDate = DateTime.UtcNow;
    }
}