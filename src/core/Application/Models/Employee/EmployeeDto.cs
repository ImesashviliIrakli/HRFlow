using Application.Models.LeaveRequest;
using Domain.ValueObjects;

namespace Application.Models.Employee;

public class EmployeeDto
{
    public Guid Id { get; set; }
    public string UserId { get; private set; }
    public string FirstName { get; set; }
    public string LastName { get; private set; }
    public string Position { get; private set; }
    public Address Address { get; private set; }
    public IReadOnlyCollection<LeaveRequestDto> LeaveRequests { get; set; }
}
