using Application.Interfaces.Messaging;
using Application.Models.Employee;
using System.ComponentModel.DataAnnotations;

namespace Application.Queries.Employees.GetEmployeeById;

public class GetEmployeeByIdQuery : IQuery<EmployeeDetailsDto>
{
    [Required]
    public Guid EmployeeId { get; private set; }

    public GetEmployeeByIdQuery(Guid employeeId)
    {
        EmployeeId = employeeId;
    }
}
