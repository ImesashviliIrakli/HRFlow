using Domain.Entities;

namespace Domain.Events;

public sealed record LeaveRequestSubmittedEvent(Guid id, LeaveRequest LeaveRequest) : DomainEvent(id);

public sealed record LeaveRequestApprovedEvent(Guid id, LeaveRequest LeaveRequest) : DomainEvent(id);
                                         
public sealed record LeaveRequestRejectedEvent(Guid id, LeaveRequest LeaveRequest) : DomainEvent(id);
