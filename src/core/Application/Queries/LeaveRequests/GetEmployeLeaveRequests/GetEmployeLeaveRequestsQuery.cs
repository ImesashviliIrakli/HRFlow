using Application.Interfaces.Messaging;
using Application.Models.LeaveRequest;

namespace Application.Queries.LeaveRequests.GetEmployeLeaveRequests;

public class GetEmployeLeaveRequestsQuery : IQuery<List<LeaveRequestDto>>
{
    public Guid EmployeeId { get; private set; }
    public GetEmployeLeaveRequestsQuery(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}
