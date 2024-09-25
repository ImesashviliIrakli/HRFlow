using System.ComponentModel.DataAnnotations;

namespace Application.Models.Employee;

public class CreateEmployeeDto
{
    [Required]
    public required string Position { get; set; }
    [Required]
    public required string Street { get; set; }
    [Required]
    public required string City { get; set; }
    [Required]
    public required string State { get; set; }
    [Required]
    public required string ZipCode { get; set; }
}
