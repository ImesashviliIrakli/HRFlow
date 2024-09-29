namespace Application.Models.LeaveRequest;

public class LeaveRequestDto
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Reason { get; private set; }
    public bool IsApproved { get; private set; }
    public string? RejectionReason { get; private set; }
    public Guid EmployeeId { get; set; }
}
