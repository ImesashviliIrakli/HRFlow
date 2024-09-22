using MediatR;

namespace Application.Commands.Employees.CreateEmployee;

public class CreateEmployeeCommand : IRequest<Guid>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Position { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
}
