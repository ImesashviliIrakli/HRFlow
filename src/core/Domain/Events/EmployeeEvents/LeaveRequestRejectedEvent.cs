using Domain.Primitives;

namespace Domain.Events.EmployeeEvents;

public class LeaveRequestRejectedEvent : DomainEvent
{
    public Guid LeaveRequestId { get; }
    public string RejectionReason { get; }
    public DateTime RejectionDate { get; }

    public LeaveRequestRejectedEvent(Guid leaveRequestId, string rejectionReason)
    {
        LeaveRequestId = leaveRequestId;
        RejectionReason = rejectionReason;
        RejectionDate = DateTime.UtcNow;
    }
}
