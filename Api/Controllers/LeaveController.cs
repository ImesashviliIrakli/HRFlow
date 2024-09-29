using Application.Commands.LeaveRequests.ApproveLeaveRequest;
using Application.Commands.LeaveRequests.RejectLeaveRequest;
using Application.Commands.LeaveRequests.SubmitLeaveRequest;
using Application.Models.LeaveRequest;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class LeaveController : BaseController
{
    private readonly IMediator _mediator;
    public LeaveController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("SubmitLeaveRequest")]
    public async Task<IActionResult> SubmitLeaveRequest([FromBody] SubmitLeaveRequest submitLeaveRequest)
    {
        var command = new SubmitLeaveRequestCommand(GetCurrentUserId(), submitLeaveRequest.StartDate, submitLeaveRequest.EndDate, submitLeaveRequest.Reason);

        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : NotFound(data.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("RejectLeaveRequest")]
    public async Task<IActionResult> RejectLeaveRequest([FromBody] RejectLeaveRequestCommand command)
    {
        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : NotFound(data.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("ApproveLeaveRequest")]
    public async Task<IActionResult> ApproveLeaveRequest([FromBody] ApproveLeaveRequestCommand command)
    {
        var data = await _mediator.Send(command);

        return data.IsSuccess ? Ok(data) : NotFound(data.Error);
    }
}
