using MediatR;

namespace Application.Commands.LeaveRequests.SubmitLeaveRequest;

public class SubmitLeaveRequestCommand : IRequest<Unit>
{
    public Guid EmployeeId { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public string Reason { get; }

    public SubmitLeaveRequestCommand(Guid employeeId, DateTime startDate, DateTime endDate, string reason)
    {
        EmployeeId = employeeId;
        StartDate = startDate;
        EndDate = endDate;
        Reason = reason;
    }
}
