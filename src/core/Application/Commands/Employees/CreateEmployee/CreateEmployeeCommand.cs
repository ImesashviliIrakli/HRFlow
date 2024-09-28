using Application.Interfaces.Messaging;
using Application.Models.Employee;
using Application.Models.Identity;
using System.Text.Json.Serialization;

namespace Application.Commands.Employees.CreateEmployee;

public class CreateEmployeeCommand : ICommand<Guid>
{
    [JsonPropertyName("registration")]
    public required RegistrationRequest RegistrationRequest { get; set; }
    [JsonPropertyName("employeeDetails")]
    public required CreateEmployeeDto CreateEmployeeDto { get; set; }
}
