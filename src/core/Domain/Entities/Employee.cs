using Domain.Events.EmployeeEvents;
using Domain.Shared;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Employee : AggregateRoot
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Position { get; private set; }
    public Address Address { get; private set; }
    private readonly List<LeaveRequest> _leaveRequests = new List<LeaveRequest>();
    public IReadOnlyCollection<LeaveRequest> LeaveRequests => _leaveRequests.AsReadOnly();

    public Employee(string firstName, string lastName, string position, Address address)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        Address = address;

        AddDomainEvent(new EmployeeCreatedEvent(this));
    }

    public void UpdateEmployeeDetails(string firstName, string lastName, string position, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        Address = address;

        AddDomainEvent(new UpdateEmployeeDetailsEvent(this));
    }

    public void ChangePosition(string newPosition)
    {
        Position = newPosition;
        AddDomainEvent(new PositionChangedEvent(this));
    }

    public void AddLeaveRequest(DateTime startDate, DateTime endDate, string reason)
    {
        var leaveRequest = new LeaveRequest(startDate, endDate, reason);
        _leaveRequests.Add(leaveRequest);
        AddDomainEvent(new LeaveRequestAddedEvent(leaveRequest));
    }

    public void ApproveLeaveRequest(Guid leaveRequestId)
    {
        var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.Id == leaveRequestId);
        if (leaveRequest != null)
        {
            leaveRequest.Approve();
            AddDomainEvent(new LeaveRequestApprovedEvent(leaveRequestId));
        }
    }

    public void RejectLeaveRequest(Guid leaveRequestId, string rejectionReason)
    {
        var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.Id == leaveRequestId);
        if (leaveRequest != null)
        {
            leaveRequest.Reject(rejectionReason);
            AddDomainEvent(new LeaveRequestRejectedEvent(leaveRequestId, rejectionReason));
        }
    }
}

