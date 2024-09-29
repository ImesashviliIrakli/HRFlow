using Application.Models.LeaveRequest;
using Domain.ValueObjects;

namespace Application.Models.Employee;

public class EmployeeDetailsDto
{
    public required Guid Id { get; set; }
    public required string UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Position { get; set; }
    public required Address Address { get; set; }
    public required IReadOnlyCollection<LeaveRequestDto> LeaveRequests { get; set; }
}
