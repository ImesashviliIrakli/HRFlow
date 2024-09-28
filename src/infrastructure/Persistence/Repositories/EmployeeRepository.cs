using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    #region Injection
    private readonly AppDbContext _context;
    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Read
    public async Task<Employee> GetEmployeeByIdAsync(Guid id)
    {
        var employee = await _context.Employees
            .Include(x => x.LeaveRequests)
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

        if (employee is null)
            throw new Exception("Not Found");

        return employee;
    }

    public async Task<Employee> GetEmployeeByUserIdAsync(string userId)
    {
        var employee = await _context.Employees
            .Include(x => x.Address)
            .Include(x => x.LeaveRequests)
            .FirstOrDefaultAsync(x => x.UserId.Equals(userId));

        if (employee is null)
            throw new Exception("Not Found");

        return employee;
    }
    #endregion

    #region Write
    public async Task AddAsync(Employee employee) => await _context.Employees.AddAsync(employee);

    public void Delete(Employee employee) => _context.Employees.Remove(employee);

    public void Update(Employee employee) => _context.Employees.Update(employee);
    #endregion

}
