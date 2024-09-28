using Domain.Entities;

namespace Domain.Repositories;

public interface ILeaveRepository
{
    Task AddAsync(LeaveRequest leaveRequest);
}
