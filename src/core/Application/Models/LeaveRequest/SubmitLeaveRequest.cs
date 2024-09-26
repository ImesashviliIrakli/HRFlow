using System.ComponentModel.DataAnnotations;

namespace Application.Models.LeaveRequest;

public class SubmitLeaveRequest
{
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    [Required]
    public required string Reason { get; set; }
}
