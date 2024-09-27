using Domain.Entities;

namespace Application.Interfaces;

public interface ILeaveRepository
{
    Task AddAsync(LeaveRequest leaveRequest);
}
