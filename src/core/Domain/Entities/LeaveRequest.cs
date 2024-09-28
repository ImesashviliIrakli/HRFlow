using Domain.Primitives;

namespace Domain.Entities;

public class LeaveRequest : Entity
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Reason { get; private set; }
    public bool IsApproved { get; private set; }
    public string? RejectionReason { get; private set; }
    public Guid EmployeeId { get; set; } 

    public LeaveRequest() {}

    public LeaveRequest(DateTime startDate, DateTime endDate, string reason, Guid employeeId)
    {
        Id = Guid.NewGuid();
        StartDate = startDate;
        EndDate = endDate;
        Reason = reason;
        IsApproved = false;
        EmployeeId = employeeId;
    }

    public void Approve()
    {
        IsApproved = true;
    }

    public void Reject(string rejectionReason)
    {
        IsApproved = false;
        RejectionReason = rejectionReason;
    }
}
