namespace Application.Models.NoSqlDocuments;

public class LeaveRequestDocument
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string? Reason { get; private set; }
    public bool IsApproved { get; private set; }
    public string? RejectionReason { get; private set; }
    public Guid EmployeeId { get; set; }
}