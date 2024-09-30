using Domain.Entities;

namespace Domain.Repositories;

public interface ILeaveRepository
{
    Task<List<LeaveRequest>> GetLeaveRequests();
    Task<List<LeaveRequest>> GetEmployeeLeaveRequests(Guid employeeId);
    Task<LeaveRequest> GetLeaveRequestById(Guid leaveRequestId);
    Task AddAsync(LeaveRequest leaveRequest);
}
