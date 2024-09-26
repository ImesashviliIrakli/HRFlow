using Domain.Entities;

namespace Application.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<Employee> GetEmployeeByUserIdAsync(string userId);
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
    Task SaveChanges(CancellationToken cancellationToken);
}
