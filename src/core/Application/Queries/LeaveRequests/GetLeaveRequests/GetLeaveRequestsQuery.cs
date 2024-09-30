using Application.Interfaces.Messaging;
using Application.Models.LeaveRequest;

namespace Application.Queries.LeaveRequests.GetLeaveRequests;

public class GetLeaveRequestsQuery : IQuery<List<LeaveRequestDto>> {}
