using MediatR;
using System.Text.Json.Serialization;

namespace Application.Commands.LeaveRequests.SubmitLeaveRequest;

public class SubmitLeaveRequestCommand : IRequest<Unit>
{
    [JsonIgnore]
    public string? UserId { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public string Reason { get; }

    public SubmitLeaveRequestCommand(string userId, DateTime startDate, DateTime endDate, string reason)
    {
        UserId = userId;
        StartDate = startDate;
        EndDate = endDate;
        Reason = reason;
    }
}
