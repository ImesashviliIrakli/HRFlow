using Application.Interfaces;
using Domain.Entities;
using Persistence.Data;

namespace Persistence.Repositories;

public class LeaveRepository : ILeaveRepository
{
    private readonly AppDbContext _context; 
    public LeaveRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(LeaveRequest leaveRequest)
    {
        await _context.LeaveRequests.AddAsync(leaveRequest);
        await _context.SaveChangesAsync();
    }
}
