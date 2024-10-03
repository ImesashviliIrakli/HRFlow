using Domain.Events;
using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Employee : AggregateRoot
{
    public string UserId { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; private set; }
    public string Position { get; private set; }
    public Address Address { get; private set; }
    private readonly List<LeaveRequest> _leaveRequests = new List<LeaveRequest>();
    public IReadOnlyCollection<LeaveRequest> LeaveRequests => _leaveRequests.AsReadOnly();

    public Employee() { }

    public Employee(string userId, string firstName, string lastName, string position, Address address)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        Address = address;

        AddDomainEvent(new EmployeeCreatedEvent(Guid.NewGuid(), this));
    }

    public void UpdateEmployeeDetails(string firstName, string lastName, string position, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        Address = address;

        AddDomainEvent(new EmployeeDetailsUpdatedEvent(Guid.NewGuid(), this));
    }

    public void ChangePosition(string newPosition)
    {
        Position = newPosition;
        AddDomainEvent(new EmployeePositionChangedEvent(Guid.NewGuid(), this));
    }

    public LeaveRequest AddLeaveRequest(DateTime startDate, DateTime endDate, string reason)
    {
        var leaveRequest = new LeaveRequest(startDate, endDate, reason, Id);
        _leaveRequests.Add(leaveRequest);
        AddDomainEvent(new LeaveRequestSubmittedEvent(Guid.NewGuid(), leaveRequest));

        return leaveRequest;
    }

    public void ApproveLeaveRequest(Guid leaveRequestId)
    {
        var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.Id == leaveRequestId);
        if (leaveRequest != null)
        {
            leaveRequest.Approve();
            AddDomainEvent(new LeaveRequestApprovedEvent(Guid.NewGuid(), leaveRequest));
        }
    }

    public void RejectLeaveRequest(Guid leaveRequestId, string rejectionReason)
    {
        var leaveRequest = _leaveRequests.FirstOrDefault(lr => lr.Id == leaveRequestId);
        if (leaveRequest != null)
        {
            leaveRequest.Reject(rejectionReason);
            AddDomainEvent(new LeaveRequestRejectedEvent(leaveRequestId, leaveRequest));
        }
    }

    public void DeleteEmployee()
    {
        AddDomainEvent(new DeleteEmployeeEvent(Guid.NewGuid(), this));
    }
}

