using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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

    #region Read
    public async Task<List<LeaveRequest>> GetEmployeeLeaveRequests(Guid employeeId)
    {
        var leaveRequests = await _context.LeaveRequests.Where(x => x.EmployeeId == employeeId).ToListAsync();

        return leaveRequests;
    }

    public async Task<LeaveRequest> GetLeaveRequestById(Guid leaveRequestId)
    {
        var leaveRequest = await _context.LeaveRequests.FirstOrDefaultAsync(x => x.Id == leaveRequestId);

        return leaveRequest;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequests()
    {
        return await _context.LeaveRequests.ToListAsync();
    }
    #endregion

    #region Write
    public async Task AddAsync(LeaveRequest leaveRequest) => await _context.LeaveRequests.AddAsync(leaveRequest);
    #endregion
}
