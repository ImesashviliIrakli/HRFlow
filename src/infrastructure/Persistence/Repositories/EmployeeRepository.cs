﻿using Application.Interfaces;
using Domain.Entities;
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
            .FirstOrDefaultAsync();

        if (employee is null)
            throw new Exception("Not Found");

        return employee;
    }
    #endregion

    #region Write
    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }
    #endregion

}