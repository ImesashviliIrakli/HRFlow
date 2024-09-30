using Application.Interfaces.Messaging;
using Application.Models.LeaveRequest;

namespace Application.Queries.LeaveRequests.GetLeaveRequestById;

public class GetLeaveRequestByIdQuery : IQuery<LeaveRequestDto>
{
    public Guid LeaveRequestId { get; private set; }
    public GetLeaveRequestByIdQuery(Guid leaveRequestId)
    {
        LeaveRequestId = leaveRequestId;
    }
}
