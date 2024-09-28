using Domain.Entities;
using Domain.Repositories;
using Persistence.Data;

namespace Persistence.Repositories;

public class LeaveRepository : ILeaveRepository
{
    #region Injection
    private readonly AppDbContext _context;
    public LeaveRepository(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Write
    public async Task AddAsync(LeaveRequest leaveRequest) => await _context.LeaveRequests.AddAsync(leaveRequest);
    #endregion
}
