using Domain.Entities;

namespace Domain.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> GetEmployeeByIdAsync(Guid id);
    Task<Employee> GetEmployeeByUserIdAsync(string userId);
    Task AddAsync(Employee employee);
    void Update(Employee employee);
    void Delete(Employee employee);
}