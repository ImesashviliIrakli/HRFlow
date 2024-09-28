using Application.Interfaces.Messaging;
using MediatR;

namespace Application.Commands.Employees.UpdateEmployeeDetails;

public class UpdateEmployeeDetailsCommand : ICommand<Unit>
{
    public Guid EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Position { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}
