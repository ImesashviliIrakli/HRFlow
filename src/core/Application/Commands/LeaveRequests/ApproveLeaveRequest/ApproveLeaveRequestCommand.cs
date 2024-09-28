using Domain.Shared;
using MediatR;

namespace Application.Commands.LeaveRequests.ApproveLeaveRequest;

public class ApproveLeaveRequestCommand : IRequest<Result>
{
    public Guid EmployeeId { get; }
    public Guid LeaveRequestId { get; }

    public ApproveLeaveRequestCommand(Guid employeeId, Guid leaveRequestId)
    {
        EmployeeId = employeeId;
        LeaveRequestId = leaveRequestId;
    }
}
